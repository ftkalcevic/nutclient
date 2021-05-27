using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace nutclient
{
    public partial class NumericTextEdit : System.Windows.Forms.TextBox
    {
        public int digits { get; set; }

        public NumericTextEdit()
        {
            digits = 6;
            InitializeComponent();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                if (TextLength < digits)
                    base.OnKeyPress(e);
                else
                    e.Handled = true;
            }
            else if ( e.KeyChar < ' ')
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }
    }
}
