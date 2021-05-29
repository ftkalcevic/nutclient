using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.Win32;

namespace nutlib
{
    public class Nut: IDisposable
    {
        private const int RECONNECT_PERIOD = 5000;
        private const int SEND_TIMEOUT_PERIOD = 30000;
        public enum EMsgType
        {
            Reponse,
            var,
            varList,
            type
        };
        /// <summary>
        /// UPS Status flags
        /// </summary>
        [Flags]
        public enum EUPSStatus
        {
            OL      = 1 << 0,   /// UPS unit is receiving power from the wall.
            OB      = 1 << 1,   /// UPS unit is not receiving power from the wall and is using its own battery to power the protected device.
            LB      = 1 << 2,   /// The battery charge is below a critical level specified by the value battery.charge.low.
            RB      = 1 << 3,   /// UPS battery needs replacing.
            CHRG    = 1 << 4,   /// The UPS battery is currently being charged.
            DISCHRG = 1 << 5,   /// The UPS battery is not being charged and is discharging.
            ALARM   = 1 << 6,   /// An alarm situation has been detected in the UPS unit.
            OVER    = 1 << 7,   /// The UPS unit is overloaded.
            TRIM    = 1 << 8,   /// The UPS voltage trimming is in operation.
            BOOST   = 1 << 9,   /// The UPS voltage boosting is in operation.
            BYPASS  = 1 << 10,  /// The UPS unit is in bypass mode.
            OFF     = 1 << 11,  /// The UPS unit is off.
            CAL     = 1 << 12,  /// The UPS unit is being calibrated.
            TEST    = 1 << 13,  /// UPS test in progress.
            FSD     = 1 << 14   /// Tell slave upsmon instances that final shutdown is underway
        };


        public delegate void VarsUpdate(EUPSStatus status, in Dictionary<string,string> vars);
        private Socket client;
        private bool connected;
        private bool suspended;
        private bool sending;
        private bool readingList;
        private bool disposedValue;
        private string username;
        private string password;
        private string host;
        private int port;
        private string upsDevice;
        private Queue<string> queue;
        private string activeMsg;
        private const int BufferSize = 256;
        private byte[] buffer = new byte[BufferSize];
        private StringBuilder sb = new StringBuilder();
        private int period;
        public Dictionary<string, string> vars;
        private Timer timer;

        public event VarsUpdate update;
        static HiddenForm hiddenForm;

        static Nut()
        {
            hiddenForm = null; 
        }

        public Nut(int pollPeriod)
        {
            period = pollPeriod*1000;   // seconds to millseconds
            disposedValue = false;
            client = null;
            connected = false;
            suspended = false;
            sending = false;
            readingList = false;
            queue = new Queue<string>();
            vars = new Dictionary<string, string>();

        }

        public void Init(bool isApplication, string host, int port, string username, string password, string upsDevice)
        {
            if (isApplication)
            {
                if ( hiddenForm == null)
                    hiddenForm = HiddenForm.startHiddenForm();
                hiddenForm.PowerModeChanged += OnPowerModeChanged;
            }

            this.username = username;
            this.password = password;
            this.host = host;
            this.port = port;
            this.upsDevice = upsDevice;

            NutLog.Log("Setting up connect timer", NutLog.ELogLevel.Debug);
            //reconnect();
            SetupReconnectTimer(250);
        }

        public void Stop()
        {
            disconnect();
        }


        private void disconnect()
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }

            if (client != null)
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                client = null;
            }
            connected = false;
        }

        private void reconnect()
        {
            try
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                NutLog.Log($"Connecting to {host}:{port}");
                client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), this);
            }
            catch (Exception e)
            {
                NutLog.Log(e.ToString());
                client = null;
                SetupReconnectTimer();
            }
        }

        public void PowerEvent(bool suspend)
        {
            if (suspend)
            {
                // About to suspend
                NutLog.Log("Suspending");
                if (connected)
                {
                    disconnect();
                    suspended = true;
                }
            }
            else 
            {
                // About to resume
                NutLog.Log("Resuming");
                if (suspended)
                {
                    if (timer != null)
                        timer.Dispose();
                    timer = new Timer(new TimerCallback(ReconnectTimerCallback));
                    timer.Change(RECONNECT_PERIOD, 0);
                    suspended = false;
                }
            }
        }

        private void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Suspend)
            {
                PowerEvent(suspend:true);
            }
            else if ( e.Mode == PowerModes.Resume )
            {
                PowerEvent(suspend: false);
            }
        }


        private void ReconnectTimerCallback(object state)
        {
            reconnect();
        }

        private void Start()
        {
            SendMessageAsync("USERNAME {username}");
            SendMessageAsync("PASSWORD {password}");
            SendMessageAsync("LIST VAR "+ upsDevice);
        }

        public void SendMessageAsync(string msg)
        {
            queue.Enqueue(msg);
            SendNext();
        }

        private void SendTimeoutCallback(object state)
        {
            sending = false;
            SendNext(activeMsg);
        }

#nullable enable
        public void SendNext(string? msg = null)
#nullable restore
        {
            if (!sending && (queue.Count > 0 || msg != null ))
            {
                if (queue.Count > 0)
                {
                    msg = queue.Dequeue();
                    activeMsg = msg;
                }

                sending = true;
                byte[] byteData = Encoding.ASCII.GetBytes(msg + "\n");

                if (timer != null)
                {
                    timer.Dispose();
                    timer = null;
                }
                timer = new Timer(new TimerCallback(SendTimeoutCallback));
                timer.Change(SEND_TIMEOUT_PERIOD, 0);

                try
                {
                    // Begin sending the data to the remote device.  
                    client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), this);
                }
                catch (Exception e)
                {
                    NutLog.Log("Failed to send: " + e.ToString());
                    SetupReconnectTimer();
                }

            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            Nut n = (Nut)ar.AsyncState;
            if (n.client == null)
                return;
            try
            {
                if (n.timer != null)
                {
                    n.timer.Dispose();
                    n.timer = null;
                }
                // Complete the connection.  
                n.client.EndConnect(ar);
                n.connected = true;

                // Begin receiving the data
                n.client.BeginReceive(n.buffer, 0, BufferSize, 0, new AsyncCallback(ReceiveCallback), n);
                NutLog.Log("Connected");

                n.Start();
            }
            catch (Exception e)
            {
                NutLog.Log(e.ToString());
                n.SetupReconnectTimer();
            }
        }

        private void SetupReconnectTimer(int period = -1)
        {
            timer = new Timer(new TimerCallback(ReconnectTimerCallback));
            timer.Change(period>=0 ? period : RECONNECT_PERIOD, 0);
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            Nut n = (Nut)ar.AsyncState;
            try
            {

                if (n.client == null)
                    return;

                // Read data from the remote device.  
                int bytesRead = n.client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    //Log($"Received {bytesRead} bytes");
                    // There might be more data, so store the data received so far.  
                    n.ProcessMessage( Encoding.ASCII.GetString(n.buffer, 0, bytesRead) );

                    // Keep listening 
                    n.client.BeginReceive(n.buffer, 0, BufferSize, 0, new AsyncCallback(ReceiveCallback), n);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (n.sb.Length > 1)
                    {
                        NutLog.Log( n.sb.ToString() );
                    }
                }
            }
            catch (Exception e)
            {
                NutLog.Log(e.ToString());
                n.SetupReconnectTimer();
            }
        }

        public void ProcessMessage(string recv)
        {
            if (readingList)
            {
                sb.Append(recv);
                if (sb.ToString().Contains("END LIST"))
                {
                    // ProcessList( sb.ToString() );
                    readingList = false;
                    NutLog.Log(sb.ToString(), NutLog.ELogLevel.Debug);
                    SendReply(EMsgType.varList, sb.ToString());
                    sending = false;
                }
            }
            else if (recv == "OK\n")
            {
                SendReply(EMsgType.Reponse, null);
                sending = false;
            }
            else if (recv.StartsWith("BEGIN LIST VAR"))
            {
                readingList = true;
                sb.Clear();
                sb.Append(recv);
            }
            else if (recv.StartsWith("TYPE"))
            {
                //ProcessVAR( recv )
                //Log(recv);
                SendReply(EMsgType.type, recv);
                sending = false;
            }
            else if (recv.StartsWith("VAR"))
            {
                //ProcessVAR( recv )
                //Log(recv);
                SendReply(EMsgType.var, recv);
                sending = false;
            }

            if (!sending)
            {
                sb.Clear();
                SendNext();
            }
        }

        private void SendReply(Nut.EMsgType type, string data)
        {
            if (type == Nut.EMsgType.varList)
            {
                Regex ex = new Regex(@"([^\s]+) ([^\s]+) ([^\s]+) (.+)");

                string[] list = data.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var s in list)
                {
                    if (s.StartsWith("BEGIN LIST VAR"))
                    {
                    }
                    else if (s.StartsWith("END LIST VAR"))
                    {
                    }
                    else
                    {
                        Match m = ex.Match(s);
                        if (m.Success && m.Groups.Count == 5)
                        {
                            string device = m.Groups[2].Value;
                            string var = m.Groups[3].Value;
                            string value = m.Groups[4].Value;

                            vars[var] = value.Trim('"');
                        }
                    }
                }
                EUPSStatus status = decodeStatus(vars["ups.status"]);
                if (update != null)
                    update(status,vars);

                RestartTimer();
            }
            else if (type == Nut.EMsgType.type)
            {
                string t = data;
            }
        }

        private EUPSStatus decodeStatus(string statusString)
        {
            string[] ss = statusString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            EUPSStatus status = 0;
            foreach (string s in ss)
            {
                switch (s.ToUpper())
                {
                    case "OL":      status |= EUPSStatus.OL; break;
                    case "OB":      status |= EUPSStatus.OB; break;
                    case "LB":      status |= EUPSStatus.LB; break;
                    case "RB":      status |= EUPSStatus.RB; break;
                    case "CHRG":    status |= EUPSStatus.CHRG; break;
                    case "DISCHRG": status |= EUPSStatus.DISCHRG; break;
                    case "ALARM":   status |= EUPSStatus.ALARM; break;
                    case "OVER":    status |= EUPSStatus.OVER; break;
                    case "TRIM":    status |= EUPSStatus.TRIM; break;
                    case "BOOST":   status |= EUPSStatus.BOOST; break;
                    case "BYPASS":  status |= EUPSStatus.BYPASS; break;
                    case "OFF":     status |= EUPSStatus.OFF; break;
                    case "CAL":     status |= EUPSStatus.CAL; break;
                    case "TEST":    status |= EUPSStatus.TEST; break;
                    case "FSD":     status |= EUPSStatus.FSD; break;
                }
            }
            return status;
        }


        private void PollTimerCallback(object state)
        {
            SendMessageAsync("LIST VAR "+ upsDevice);
            //PowerModeChangedEventArgs e = new PowerModeChangedEventArgs(PowerModes.Suspend);
            //OnPowerModeChanged(null, e);
        }

            private void RestartTimer()
        {
            if (timer == null)
                timer = new Timer(new TimerCallback(PollTimerCallback));
            timer.Change(period, 0);
        }


        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Nut n = (Nut)ar.AsyncState;
                if (n.client == null)
                    return;

                // Complete sending the data to the remote device.  
                int bytesSent = n.client.EndSend(ar);
                // Log($"Sent {bytesSent} bytes to server.");
           }
            catch (Exception e)
            {
                NutLog.Log(e.ToString());
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                if (connected)
                {
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                    connected = false;
                }
                disposedValue = true;
            }
        }

        ~Nut()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

/*
[ol] UPS unit is receiving power from the wall.
[ob] UPS unit is not receiving power from the wall and is using its own battery to power the protected device.
[lb] The battery charge is below a critical level specified by the value battery.charge.low.
[rb] UPS battery needs replacing.
[chrg] The UPS battery is currently being charged.
[dischrg] The UPS battery is not being charged and is discharging.
[alarm] An alarm situation has been detected in the UPS unit.
[over] The UPS unit is overloaded.
[trim] The UPS voltage trimming is in operation.
[boost] The UPS voltage boosting is in operation.
[bypass] The UPS unit is in bypass mode.
[off] The UPS unit is off.
[cal] The UPS unit is being calibrated.
[test] UPS test in progress.
[fsd] Tell slave upsmon instances that final shutdown is underway

* shutdown options
    * after n seconds
    * n seconds left
    * when power drops to n
    * when FSD
* shutdown or hybernate

 */