using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using nutlib;
using Microsoft.Win32;

namespace nutclient
{
    public partial class MainForm : Form
    {
        const int MAX_LOG_LEN_HIGH = 9000;
        const int MAX_LOG_LEN_LOW = 8000;
        NutControl nut;
        private static int WM_QUERYENDSESSION = 0x11;
        private static bool systemShutdown = false;

        public MainForm()
        {
            InitializeComponent();
            notifyIcon.Icon = Properties.Resources.NotifyIcon;

            NutLog.LogEvent += NutLog_LogEvent;
            nut = new NutControl(application:true);
            nut.nut.update += Nut_update;

            InitDisplay();
        }


        private void NutLog_LogEvent(string msg)
        {
            txtLog.Invoke( 
                (MethodInvoker)delegate 
                {
                    if (txtLog.TextLength > MAX_LOG_LEN_HIGH)
                    {
                        txtLog.Select(0, MAX_LOG_LEN_LOW);
                        txtLog.SelectedText = "";
                    }
                    txtLog.AppendText( msg + "\r\n" );
                }
            );
        }

        private void InitDisplay()
        {
            txtPercentRemaining.Text = nut.cfg.percentRemaining.ToString();
            txtSecondRemaining.Text = nut.cfg.secondsRemaining.ToString();
            txtSecondsOnBattery.Text = nut.cfg.afterSeconds.ToString();
            chkMinimiseToTray.Checked = nut.cfg.minimiseToTray;
            chkStartWithWindows.Checked = nut.cfg.startWithWindows;
            txtHostname.Text = nut.cfg.hostname;
            txtPort.Text = nut.cfg.port.ToString();
            txtUsername.Text = nut.cfg.username;
            txtUPSDevice.Text = nut.cfg.upsDevice;
            txtPollPeriod.Text = nut.cfg.pollPeriod.ToString();

            setCondition(nut.cfg.shutdownCondition);
            setAction(nut.cfg.shutdownAction);
            setRunAs(nut.cfg.runAs);
            EnableControls();
        }

        private void setRunAs(NutConfig.ERunAs runAs)
        {
            switch (runAs)
            {
                default:
                case NutConfig.ERunAs.Application: radioRunAsApplication.Checked = true; break;
                case NutConfig.ERunAs.Service: radioRunAsService.Checked = true; break;
            }
        }

        private void setAction(NutConfig.EShutdownAction shutdownAction)
        {
            switch (shutdownAction)
            {
                default:
                case NutConfig.EShutdownAction.Shutdown: radioActionShutdown.Checked = true; break;
                case NutConfig.EShutdownAction.Hibernate: radioActionHibernate.Checked = true; break;
            }
        }

        private void setCondition(NutConfig.EShutdownCondition shutdownCondition)
        {
            switch (shutdownCondition   )
            {
                default:
                case NutConfig.EShutdownCondition.finalShutdown: radioConditionFinalShutdown.Checked = true; break;
                case NutConfig.EShutdownCondition.afterNSeconds: radioConditionAfterSeconds.Checked = true; break;
                case NutConfig.EShutdownCondition.belowNPercent: radioConditionBelowPercent.Checked = true; break;
                case NutConfig.EShutdownCondition.nSecondsRemaining: radioConditionRemainingSeconds.Checked = true; break;
            }
        }

        private void radioConditionCheckedChanged(object sender, EventArgs e)
        {
            if (radioConditionFinalShutdown.Checked)
                nut.cfg.shutdownCondition = NutConfig.EShutdownCondition.finalShutdown;
            else if (radioConditionAfterSeconds.Checked)
                nut.cfg.shutdownCondition = NutConfig.EShutdownCondition.afterNSeconds;
            else if (radioConditionBelowPercent.Checked)
                nut.cfg.shutdownCondition = NutConfig.EShutdownCondition.belowNPercent;
            else
                nut.cfg.shutdownCondition = NutConfig.EShutdownCondition.nSecondsRemaining;
            EnableControls();
        }

        private void radioActionCheckedChanged(object sender, EventArgs e)
        {
            if (radioActionHibernate.Checked)
                nut.cfg.shutdownAction = NutConfig.EShutdownAction.Hibernate;
            else
                nut.cfg.shutdownAction = NutConfig.EShutdownAction.Shutdown;
            EnableControls();
        }

        private void radioRunAsCheckedChanged(object sender, EventArgs e)
        {
            if (radioRunAsApplication.Checked)
                nut.cfg.runAs = NutConfig.ERunAs.Application;
            else
                nut.cfg.runAs = NutConfig.ERunAs.Service;
            EnableControls();
        }

        void EnableControls()
        {
            bool runAsApp = (nut.cfg.runAs == NutConfig.ERunAs.Application);
            chkMinimiseToTray.Enabled = runAsApp;
            chkStartWithWindows.Enabled = runAsApp;
            radioRunAsService.ForeColor = !runAsApp ? SystemColors.ControlText : SystemColors.GrayText;
            radioRunAsApplication.ForeColor = runAsApp ? SystemColors.ControlText : SystemColors.GrayText;
            btnServiceInstall.Enabled = !runAsApp;

            bool shutdown = (nut.cfg.shutdownAction == NutConfig.EShutdownAction.Shutdown);
            radioActionShutdown.ForeColor = shutdown ? SystemColors.ControlText : SystemColors.GrayText;
            radioActionHibernate.ForeColor = !shutdown ? SystemColors.ControlText : SystemColors.GrayText;

            bool afterNsecs = (nut.cfg.shutdownCondition == NutConfig.EShutdownCondition.afterNSeconds);
            bool belowNPercent = (nut.cfg.shutdownCondition == NutConfig.EShutdownCondition.belowNPercent);
            bool finalShutdown = (nut.cfg.shutdownCondition == NutConfig.EShutdownCondition.finalShutdown);
            bool secondsRemaining = (nut.cfg.shutdownCondition == NutConfig.EShutdownCondition.nSecondsRemaining);

            radioConditionAfterSeconds.ForeColor = afterNsecs ? SystemColors.ControlText : SystemColors.GrayText;
            txtSecondsOnBattery.Enabled = afterNsecs;
            lblConditionAfterSeconds.Enabled = afterNsecs;

            radioConditionBelowPercent.ForeColor = belowNPercent ? SystemColors.ControlText : SystemColors.GrayText;
            txtPercentRemaining.Enabled = belowNPercent;
            lblConditionBelowPercent.Enabled = belowNPercent;

            radioConditionFinalShutdown.ForeColor = finalShutdown ? SystemColors.ControlText : SystemColors.GrayText;

            radioConditionRemainingSeconds.ForeColor = secondsRemaining ? SystemColors.ControlText : SystemColors.GrayText;
            txtSecondRemaining.Enabled = secondsRemaining;
            lblConditionRemainingSeconds.Enabled = secondsRemaining;

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            nut.cfg.afterSeconds = int.Parse(txtSecondsOnBattery.Text);
            nut.cfg.secondsRemaining = int.Parse(txtSecondRemaining.Text);
            nut.cfg.percentRemaining = int.Parse(txtPercentRemaining.Text);
            nut.cfg.hostname = txtHostname.Text;
            nut.cfg.port = int.Parse(txtPort.Text);
            nut.cfg.upsDevice = txtUPSDevice.Text;
            nut.cfg.pollPeriod = int.Parse(txtPollPeriod.Text);
            if (txtPassword.TextLength > 0)
                nut.cfg.password = txtPassword.Text;
            nut.cfg.minimiseToTray = chkMinimiseToTray.Checked;
            nut.cfg.startWithWindows = chkStartWithWindows.Checked;

            if (nut.cfg.startWithWindows && nut.cfg.runAs == NutConfig.ERunAs.Application)
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            else
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, "");

            nut.cfg.write();

            nut.Stop();
            nut.nut.update -= Nut_update;

            nut = new NutControl(application: true);
            nut.nut.update += Nut_update;
            nut.Start();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            nut.Start();
        }

        private void Nut_update(Nut.EUPSStatus estatus, in Dictionary<string, string> vars)
        {
            string status = vars["ups.status"];
            int runtime = int.Parse(vars["battery.runtime"]);
            int batteryCharge = int.Parse(vars["battery.charge"]);

            Invoke((MethodInvoker)delegate {
                txtStatus.Text = status;
                txtRunTime.Text = runtime.ToString();
                txtBatteryCharge.Text = batteryCharge.ToString();
                txtLastUpdate.Text = DateTime.Now.ToString();

                notifyIcon.Text = "Status: " + status;
                notifyIcon.BalloonTipText = "Status: " + status;
                notifyIcon.BalloonTipTitle = "NUTClient";
            });
        }

        private void btnServiceInstall_Click(object sender, EventArgs e)
        {

        }

        private void btnTestShutdown_Click(object sender, EventArgs e)
        {
            nut.Shutdown();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (nut.cfg.minimiseToTray)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.ShowInTaskbar = false;
                    notifyIcon.Visible = true;
                    notifyIcon.ShowBalloonTip(1000);
                }
                else
                {
                    notifyIcon.Visible = false;
                    this.Visible = true;
                }
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!systemShutdown && nut.isActive)
            {
                DialogResult res = MessageBox.Show(this,"NutClient is actively monitoring the UPS.\r\nAre you sure you want to exit?","Confirm exit",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
                if (res != DialogResult.OK)
                    e.Cancel = true;
            }
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            // The .net method of querying end session is not guaranteed to occur before form_closing
            if (m.Msg == WM_QUERYENDSESSION)
            {
                systemShutdown = true;
            }

            base.WndProc(ref m);
        }
    }
}
