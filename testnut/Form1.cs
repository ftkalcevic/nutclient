using nutlib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace testnut
{
    public partial class Form1 : Form
    {
        Nut nut;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nut = new Nut();

            nut.reply += Nut_reply;
            nut.Init("nas2", 3493, "upsmon", "secret");

        }

        private void Nut_reply(Nut.EMsgType type, string data)
        {
            if (type == Nut.EMsgType.varList)
            {
                string[] list = data.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                foreach (var s in list)
                {
                }
            }
        }
    }
}
