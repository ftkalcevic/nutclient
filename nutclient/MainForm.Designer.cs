
namespace nutclient
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBatteryCharge = new System.Windows.Forms.TextBox();
            this.txtRunTime = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtLastUpdate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtPort = new nutclient.NumericTextEdit();
            this.txtPollPeriod = new nutclient.NumericTextEdit();
            this.txtUPSDevice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHostname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnServiceInstall = new System.Windows.Forms.Button();
            this.chkMinimiseToTray = new System.Windows.Forms.CheckBox();
            this.chkStartWithWindows = new System.Windows.Forms.CheckBox();
            this.radioRunAsApplication = new System.Windows.Forms.RadioButton();
            this.radioRunAsService = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioActionHibernate = new System.Windows.Forms.RadioButton();
            this.radioActionShutdown = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPercentRemaining = new nutclient.NumericTextEdit();
            this.txtSecondRemaining = new nutclient.NumericTextEdit();
            this.txtSecondsOnBattery = new nutclient.NumericTextEdit();
            this.radioConditionFinalShutdown = new System.Windows.Forms.RadioButton();
            this.lblConditionBelowPercent = new System.Windows.Forms.Label();
            this.radioConditionBelowPercent = new System.Windows.Forms.RadioButton();
            this.lblConditionRemainingSeconds = new System.Windows.Forms.Label();
            this.radioConditionRemainingSeconds = new System.Windows.Forms.RadioButton();
            this.lblConditionAfterSeconds = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioConditionAfterSeconds = new System.Windows.Forms.RadioButton();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnTestShutdown = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageMain);
            this.tabControl1.Controls.Add(this.tabPageConfig);
            this.tabControl1.Location = new System.Drawing.Point(0, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(367, 553);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.label14);
            this.tabPageMain.Controls.Add(this.txtLog);
            this.tabPageMain.Controls.Add(this.label13);
            this.tabPageMain.Controls.Add(this.label12);
            this.tabPageMain.Controls.Add(this.label11);
            this.tabPageMain.Controls.Add(this.label10);
            this.tabPageMain.Controls.Add(this.label9);
            this.tabPageMain.Controls.Add(this.txtBatteryCharge);
            this.tabPageMain.Controls.Add(this.txtRunTime);
            this.tabPageMain.Controls.Add(this.txtStatus);
            this.tabPageMain.Controls.Add(this.txtLastUpdate);
            this.tabPageMain.Controls.Add(this.label8);
            this.tabPageMain.Location = new System.Drawing.Point(4, 24);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(359, 525);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 148);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 15);
            this.label14.TabIndex = 12;
            this.label14.Text = "Log";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(9, 170);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(338, 349);
            this.txtLog.TabIndex = 11;
            this.txtLog.WordWrap = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(201, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 15);
            this.label13.TabIndex = 9;
            this.label13.Text = "percent";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(198, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 15);
            this.label12.TabIndex = 8;
            this.label12.Text = "seconds";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 15);
            this.label11.TabIndex = 7;
            this.label11.Text = "Battery Charge";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "Run Time";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "Status";
            // 
            // txtBatteryCharge
            // 
            this.txtBatteryCharge.Location = new System.Drawing.Point(100, 100);
            this.txtBatteryCharge.Name = "txtBatteryCharge";
            this.txtBatteryCharge.ReadOnly = true;
            this.txtBatteryCharge.Size = new System.Drawing.Size(95, 23);
            this.txtBatteryCharge.TabIndex = 4;
            // 
            // txtRunTime
            // 
            this.txtRunTime.Location = new System.Drawing.Point(100, 70);
            this.txtRunTime.Name = "txtRunTime";
            this.txtRunTime.ReadOnly = true;
            this.txtRunTime.Size = new System.Drawing.Size(95, 23);
            this.txtRunTime.TabIndex = 3;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(100, 41);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(148, 23);
            this.txtStatus.TabIndex = 2;
            // 
            // txtLastUpdate
            // 
            this.txtLastUpdate.Location = new System.Drawing.Point(100, 10);
            this.txtLastUpdate.Name = "txtLastUpdate";
            this.txtLastUpdate.ReadOnly = true;
            this.txtLastUpdate.Size = new System.Drawing.Size(148, 23);
            this.txtLastUpdate.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Last Update";
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.groupBox4);
            this.tabPageConfig.Controls.Add(this.btnApply);
            this.tabPageConfig.Controls.Add(this.groupBox3);
            this.tabPageConfig.Controls.Add(this.groupBox2);
            this.tabPageConfig.Controls.Add(this.groupBox1);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 24);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfig.Size = new System.Drawing.Size(359, 525);
            this.tabPageConfig.TabIndex = 1;
            this.tabPageConfig.Text = "Config";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtPort);
            this.groupBox4.Controls.Add(this.txtPollPeriod);
            this.groupBox4.Controls.Add(this.txtUPSDevice);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtPassword);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtUsername);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtHostname);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(9, 316);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 203);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "NUT Config";
            // 
            // txtPort
            // 
            this.txtPort.digits = 6;
            this.txtPort.Location = new System.Drawing.Point(75, 49);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(67, 23);
            this.txtPort.TabIndex = 6;
            // 
            // txtPollPeriod
            // 
            this.txtPollPeriod.digits = 6;
            this.txtPollPeriod.Location = new System.Drawing.Point(75, 165);
            this.txtPollPeriod.Name = "txtPollPeriod";
            this.txtPollPeriod.Size = new System.Drawing.Size(100, 23);
            this.txtPollPeriod.TabIndex = 12;
            // 
            // txtUPSDevice
            // 
            this.txtUPSDevice.Location = new System.Drawing.Point(75, 136);
            this.txtUPSDevice.Name = "txtUPSDevice";
            this.txtUPSDevice.Size = new System.Drawing.Size(100, 23);
            this.txtUPSDevice.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Poll Period";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "UPS Device";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(75, 107);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 23);
            this.txtPassword.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(75, 78);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 23);
            this.txtUsername.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Port";
            // 
            // txtHostname
            // 
            this.txtHostname.Location = new System.Drawing.Point(75, 20);
            this.txtHostname.Name = "txtHostname";
            this.txtHostname.Size = new System.Drawing.Size(100, 23);
            this.txtHostname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Hostname";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(272, 436);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnServiceInstall);
            this.groupBox3.Controls.Add(this.chkMinimiseToTray);
            this.groupBox3.Controls.Add(this.chkStartWithWindows);
            this.groupBox3.Controls.Add(this.radioRunAsApplication);
            this.groupBox3.Controls.Add(this.radioRunAsService);
            this.groupBox3.Location = new System.Drawing.Point(163, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(182, 133);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Run as";
            // 
            // btnServiceInstall
            // 
            this.btnServiceInstall.Location = new System.Drawing.Point(101, 21);
            this.btnServiceInstall.Name = "btnServiceInstall";
            this.btnServiceInstall.Size = new System.Drawing.Size(75, 23);
            this.btnServiceInstall.TabIndex = 4;
            this.btnServiceInstall.Text = "Install";
            this.btnServiceInstall.UseVisualStyleBackColor = true;
            this.btnServiceInstall.Click += new System.EventHandler(this.btnServiceInstall_Click);
            // 
            // chkMinimiseToTray
            // 
            this.chkMinimiseToTray.AutoSize = true;
            this.chkMinimiseToTray.Location = new System.Drawing.Point(29, 97);
            this.chkMinimiseToTray.Name = "chkMinimiseToTray";
            this.chkMinimiseToTray.Size = new System.Drawing.Size(112, 19);
            this.chkMinimiseToTray.TabIndex = 3;
            this.chkMinimiseToTray.Text = "Minimise to tray";
            this.chkMinimiseToTray.UseVisualStyleBackColor = true;
            // 
            // chkStartWithWindows
            // 
            this.chkStartWithWindows.AutoSize = true;
            this.chkStartWithWindows.Location = new System.Drawing.Point(29, 72);
            this.chkStartWithWindows.Name = "chkStartWithWindows";
            this.chkStartWithWindows.Size = new System.Drawing.Size(126, 19);
            this.chkStartWithWindows.TabIndex = 2;
            this.chkStartWithWindows.Text = "Start with windows";
            this.chkStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // radioRunAsApplication
            // 
            this.radioRunAsApplication.AutoSize = true;
            this.radioRunAsApplication.Location = new System.Drawing.Point(6, 47);
            this.radioRunAsApplication.Name = "radioRunAsApplication";
            this.radioRunAsApplication.Size = new System.Drawing.Size(86, 19);
            this.radioRunAsApplication.TabIndex = 1;
            this.radioRunAsApplication.TabStop = true;
            this.radioRunAsApplication.Text = "Application";
            this.radioRunAsApplication.UseVisualStyleBackColor = true;
            this.radioRunAsApplication.CheckedChanged += new System.EventHandler(this.radioRunAsCheckedChanged);
            // 
            // radioRunAsService
            // 
            this.radioRunAsService.AutoSize = true;
            this.radioRunAsService.Location = new System.Drawing.Point(6, 22);
            this.radioRunAsService.Name = "radioRunAsService";
            this.radioRunAsService.Size = new System.Drawing.Size(62, 19);
            this.radioRunAsService.TabIndex = 0;
            this.radioRunAsService.TabStop = true;
            this.radioRunAsService.Text = "Service";
            this.radioRunAsService.UseVisualStyleBackColor = true;
            this.radioRunAsService.CheckedChanged += new System.EventHandler(this.radioRunAsCheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTestShutdown);
            this.groupBox2.Controls.Add(this.radioActionHibernate);
            this.groupBox2.Controls.Add(this.radioActionShutdown);
            this.groupBox2.Location = new System.Drawing.Point(8, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 133);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // radioActionHibernate
            // 
            this.radioActionHibernate.AutoSize = true;
            this.radioActionHibernate.Location = new System.Drawing.Point(6, 48);
            this.radioActionHibernate.Name = "radioActionHibernate";
            this.radioActionHibernate.Size = new System.Drawing.Size(77, 19);
            this.radioActionHibernate.TabIndex = 1;
            this.radioActionHibernate.TabStop = true;
            this.radioActionHibernate.Text = "Hibernate";
            this.radioActionHibernate.UseVisualStyleBackColor = true;
            this.radioActionHibernate.CheckedChanged += new System.EventHandler(this.radioActionCheckedChanged);
            // 
            // radioActionShutdown
            // 
            this.radioActionShutdown.AutoSize = true;
            this.radioActionShutdown.Location = new System.Drawing.Point(6, 23);
            this.radioActionShutdown.Name = "radioActionShutdown";
            this.radioActionShutdown.Size = new System.Drawing.Size(79, 19);
            this.radioActionShutdown.TabIndex = 0;
            this.radioActionShutdown.TabStop = true;
            this.radioActionShutdown.Text = "Shutdown";
            this.radioActionShutdown.UseVisualStyleBackColor = true;
            this.radioActionShutdown.CheckedChanged += new System.EventHandler(this.radioActionCheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPercentRemaining);
            this.groupBox1.Controls.Add(this.txtSecondRemaining);
            this.groupBox1.Controls.Add(this.txtSecondsOnBattery);
            this.groupBox1.Controls.Add(this.radioConditionFinalShutdown);
            this.groupBox1.Controls.Add(this.lblConditionBelowPercent);
            this.groupBox1.Controls.Add(this.radioConditionBelowPercent);
            this.groupBox1.Controls.Add(this.lblConditionRemainingSeconds);
            this.groupBox1.Controls.Add(this.radioConditionRemainingSeconds);
            this.groupBox1.Controls.Add(this.lblConditionAfterSeconds);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioConditionAfterSeconds);
            this.groupBox1.Location = new System.Drawing.Point(8, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Condition";
            // 
            // txtPercentRemaining
            // 
            this.txtPercentRemaining.digits = 6;
            this.txtPercentRemaining.Location = new System.Drawing.Point(145, 96);
            this.txtPercentRemaining.Name = "txtPercentRemaining";
            this.txtPercentRemaining.Size = new System.Drawing.Size(67, 23);
            this.txtPercentRemaining.TabIndex = 13;
            // 
            // txtSecondRemaining
            // 
            this.txtSecondRemaining.digits = 6;
            this.txtSecondRemaining.Location = new System.Drawing.Point(56, 69);
            this.txtSecondRemaining.Name = "txtSecondRemaining";
            this.txtSecondRemaining.Size = new System.Drawing.Size(67, 23);
            this.txtSecondRemaining.TabIndex = 12;
            // 
            // txtSecondsOnBattery
            // 
            this.txtSecondsOnBattery.digits = 6;
            this.txtSecondsOnBattery.Location = new System.Drawing.Point(56, 42);
            this.txtSecondsOnBattery.Name = "txtSecondsOnBattery";
            this.txtSecondsOnBattery.Size = new System.Drawing.Size(67, 23);
            this.txtSecondsOnBattery.TabIndex = 11;
            // 
            // radioConditionFinalShutdown
            // 
            this.radioConditionFinalShutdown.AutoSize = true;
            this.radioConditionFinalShutdown.Location = new System.Drawing.Point(6, 124);
            this.radioConditionFinalShutdown.Name = "radioConditionFinalShutdown";
            this.radioConditionFinalShutdown.Size = new System.Drawing.Size(148, 19);
            this.radioConditionFinalShutdown.TabIndex = 10;
            this.radioConditionFinalShutdown.TabStop = true;
            this.radioConditionFinalShutdown.Text = "at FSD (final shutdown)";
            this.radioConditionFinalShutdown.UseVisualStyleBackColor = true;
            this.radioConditionFinalShutdown.CheckedChanged += new System.EventHandler(this.radioConditionCheckedChanged);
            // 
            // lblConditionBelowPercent
            // 
            this.lblConditionBelowPercent.AutoSize = true;
            this.lblConditionBelowPercent.Location = new System.Drawing.Point(219, 99);
            this.lblConditionBelowPercent.Name = "lblConditionBelowPercent";
            this.lblConditionBelowPercent.Size = new System.Drawing.Size(50, 15);
            this.lblConditionBelowPercent.TabIndex = 9;
            this.lblConditionBelowPercent.Text = "percent.";
            // 
            // radioConditionBelowPercent
            // 
            this.radioConditionBelowPercent.AutoSize = true;
            this.radioConditionBelowPercent.Location = new System.Drawing.Point(6, 97);
            this.radioConditionBelowPercent.Name = "radioConditionBelowPercent";
            this.radioConditionBelowPercent.Size = new System.Drawing.Size(137, 19);
            this.radioConditionBelowPercent.TabIndex = 7;
            this.radioConditionBelowPercent.TabStop = true;
            this.radioConditionBelowPercent.Text = "when power drops to";
            this.radioConditionBelowPercent.UseVisualStyleBackColor = true;
            this.radioConditionBelowPercent.CheckedChanged += new System.EventHandler(this.radioConditionCheckedChanged);
            // 
            // lblConditionRemainingSeconds
            // 
            this.lblConditionRemainingSeconds.AutoSize = true;
            this.lblConditionRemainingSeconds.Location = new System.Drawing.Point(128, 72);
            this.lblConditionRemainingSeconds.Name = "lblConditionRemainingSeconds";
            this.lblConditionRemainingSeconds.Size = new System.Drawing.Size(169, 15);
            this.lblConditionRemainingSeconds.TabIndex = 6;
            this.lblConditionRemainingSeconds.Text = "seconds of runtime remaining.";
            // 
            // radioConditionRemainingSeconds
            // 
            this.radioConditionRemainingSeconds.AutoSize = true;
            this.radioConditionRemainingSeconds.Location = new System.Drawing.Point(6, 70);
            this.radioConditionRemainingSeconds.Name = "radioConditionRemainingSeconds";
            this.radioConditionRemainingSeconds.Size = new System.Drawing.Size(48, 19);
            this.radioConditionRemainingSeconds.TabIndex = 4;
            this.radioConditionRemainingSeconds.TabStop = true;
            this.radioConditionRemainingSeconds.Text = "with";
            this.radioConditionRemainingSeconds.UseVisualStyleBackColor = true;
            this.radioConditionRemainingSeconds.CheckedChanged += new System.EventHandler(this.radioConditionCheckedChanged);
            // 
            // lblConditionAfterSeconds
            // 
            this.lblConditionAfterSeconds.AutoSize = true;
            this.lblConditionAfterSeconds.Location = new System.Drawing.Point(128, 45);
            this.lblConditionAfterSeconds.Name = "lblConditionAfterSeconds";
            this.lblConditionAfterSeconds.Size = new System.Drawing.Size(110, 15);
            this.lblConditionAfterSeconds.TabIndex = 3;
            this.lblConditionAfterSeconds.Tag = "";
            this.lblConditionAfterSeconds.Text = "seconds on battery.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shutdown...";
            // 
            // radioConditionAfterSeconds
            // 
            this.radioConditionAfterSeconds.AutoSize = true;
            this.radioConditionAfterSeconds.Location = new System.Drawing.Point(6, 43);
            this.radioConditionAfterSeconds.Name = "radioConditionAfterSeconds";
            this.radioConditionAfterSeconds.Size = new System.Drawing.Size(49, 19);
            this.radioConditionAfterSeconds.TabIndex = 0;
            this.radioConditionAfterSeconds.TabStop = true;
            this.radioConditionAfterSeconds.Text = "after";
            this.radioConditionAfterSeconds.UseVisualStyleBackColor = true;
            this.radioConditionAfterSeconds.CheckedChanged += new System.EventHandler(this.radioConditionCheckedChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // btnTestShutdown
            // 
            this.btnTestShutdown.Location = new System.Drawing.Point(23, 93);
            this.btnTestShutdown.Name = "btnTestShutdown";
            this.btnTestShutdown.Size = new System.Drawing.Size(100, 23);
            this.btnTestShutdown.TabIndex = 11;
            this.btnTestShutdown.Text = "Test Shutdown";
            this.btnTestShutdown.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 558);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "NUT Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.tabPageConfig.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageConfig;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioConditionAfterSeconds;
        private System.Windows.Forms.Label lblConditionAfterSeconds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioConditionRemainingSeconds;
        private System.Windows.Forms.Label lblConditionRemainingSeconds;
        private System.Windows.Forms.Label lblConditionBelowPercent;
        private System.Windows.Forms.RadioButton radioConditionBelowPercent;
        private System.Windows.Forms.RadioButton radioConditionFinalShutdown;
        private System.Windows.Forms.RadioButton radioActionHibernate;
        private System.Windows.Forms.RadioButton radioActionShutdown;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkMinimiseToTray;
        private System.Windows.Forms.CheckBox chkStartWithWindows;
        private System.Windows.Forms.RadioButton radioRunAsApplication;
        private System.Windows.Forms.RadioButton radioRunAsService;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHostname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUPSDevice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBatteryCharge;
        private System.Windows.Forms.TextBox txtRunTime;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtLastUpdate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnServiceInstall;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private NumericTextEdit txtPort;
        private NumericTextEdit txtPollPeriod;
        private NumericTextEdit txtPercentRemaining;
        private NumericTextEdit txtSecondRemaining;
        private NumericTextEdit txtSecondsOnBattery;
        private System.Windows.Forms.Button btnTestShutdown;
    }
}

