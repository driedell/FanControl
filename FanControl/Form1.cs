using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FanControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(textBox1.Text);

            if (value > 255)
            {
                value = 255;
                textBox1.Text = "255";
            }
            else if (value < 0)
            {
                value = 0;
                textBox1.Text = "0";
            }

            trackBar1.Value = value;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
    }
}
