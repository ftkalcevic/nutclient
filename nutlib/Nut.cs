using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;

namespace nutlib
{
    public class Nut: IDisposable
    {
        public enum EMsgType
        {
            Reponse,
            var,
            varList
        };
        public delegate void MessageReply(EMsgType type, string data);
        private Socket client;
        private bool connected;
        public bool sending;
        public bool readingList;
        private bool disposedValue;
        private string username;
        private string password;
        private Queue<string> queue;
        private const int BufferSize = 256;
        private byte[] buffer = new byte[BufferSize];
        private StringBuilder sb = new StringBuilder();

        public event MessageReply reply;

        public Nut()
        {
            disposedValue = false;
            client = null;
            connected = false;
            sending = false;
            readingList = false;
            queue = new Queue<string>();
        }

        public void Init(string host, int port, string username, string password)
        {
            this.username = username;
            this.password = password;
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            Log($"Connecting to {host}:{port}");
            client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), this);
        }

        private void Start()
        {
            SendMessageAsync("USERNAME {username}");
            SendMessageAsync("PASSWORD {password}");
            SendMessageAsync("LIST VAR ups");
        }

        public void SendMessageAsync(string msg)
        {
            queue.Enqueue(msg);
            SendNext();
        }

        public void SendNext()
        {
            if (!sending && queue.Count > 0)
            {
                sending = true;
                string data = queue.Dequeue();
                byte[] byteData = Encoding.ASCII.GetBytes(data + "\n");

                // Begin sending the data to the remote device.  
                client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), this);
            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Complete the connection.  
                Nut n = (Nut)ar.AsyncState;
                n.client.EndConnect(ar);
                n.connected = true;

                // Begin receiving the data
                n.client.BeginReceive(n.buffer, 0, BufferSize, 0, new AsyncCallback(ReceiveCallback), n);
                Log("Connected");

                n.Start();
            }
            catch (Exception e)
            {
                Log(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                Nut n = (Nut)ar.AsyncState;

                // Read data from the remote device.  
                int bytesRead = n.client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    Log($"Received {bytesRead} bytes");
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
                        Log( n.sb.ToString() );
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
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
                    Log(sb.ToString());
                    if (reply != null)
                        reply(EMsgType.varList, sb.ToString());
                    sending = false;
                }
            }
            else if (recv == "OK\n")
            {
                if (reply != null)
                    reply(EMsgType.Reponse, null);
                sending = false;
            }
            else if (recv.StartsWith("BEGIN LIST VAR"))
            {
                readingList = true;
                sb.Clear();
                sb.Append(recv);
            }
            else if (recv.StartsWith("VAR"))
            {
                //ProcessVAR( recv )
                Log(recv);
                if (reply != null)
                    reply(EMsgType.var, recv);
                sending = false;
            }

            if (!sending)
            {
                sb.Clear();
                SendNext();
            }
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Nut n = (Nut)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = n.client.EndSend(ar);
                Log($"Sent {bytesSent} bytes to server.");
           }
            catch (Exception e)
            {
                Log(e.ToString());
            }
        }

        static private void Log(string msg)
        {
            System.Diagnostics.Debug.WriteLine(msg);
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
