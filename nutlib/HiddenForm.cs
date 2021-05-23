using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Win32;

namespace nutlib
{
    internal class HiddenForm : Form
    {
        public event PowerModeChangedEventHandler PowerModeChanged;

        public HiddenForm()
        {
            InitializeComponent();
        }

        private void HiddenForm_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
        }

        private void HiddenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SystemEvents.PowerModeChanged -= SystemEvents_PowerModeChanged;
        }

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (PowerModeChanged != null)
                PowerModeChanged(null,e);
        }
    
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HiddenForm";
            this.Text = "HiddenForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.HiddenForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HiddenForm_FormClosing);
            this.ResumeLayout(false);
        }

        public static HiddenForm startHiddenForm()
        {
            HiddenForm f = new HiddenForm();
            if (Application.MessageLoop)
                f.Show();
            else
                Application.Run(f);
            return f;
        }

    }
}
