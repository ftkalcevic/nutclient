using nutlib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace testnut
{
    public partial class Form1 : Form
    {
        Nut nut;
        const int POLL_PERIOD = 15000;  // 15 sec

        public Form1()
        {
            nut = null;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nut = new Nut(POLL_PERIOD);

            nut.update += Nut_update;
            nut.Init("nas2", 3493, "upsmon", "secret");

        }

        private void Nut_update(Nut.EUPSStatus estatus, in Dictionary<string, string> vars)
        {
            string status = vars["ups.status"].Trim('"');
            int runtime = int.Parse(vars["battery.runtime"].Trim('"'));

            Invoke((MethodInvoker)delegate {
                txtStatus.Text = status;
                txtRunTime.Text = runtime.ToString();
            });
        }
    }
}
