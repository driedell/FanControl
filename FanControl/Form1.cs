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

            fanPanel myFanPanel = new fanPanel(tableLayoutPanel1, tableLayoutPanel1.ColumnCount - 1);
            myFanPanel.label1.Text = "fan" + (tableLayoutPanel1.ColumnCount - 1).ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnCount++;
            fanPanel myFanPanel = new fanPanel(tableLayoutPanel1, tableLayoutPanel1.ColumnCount-1);
            myFanPanel.label1.Text = "fan" + (tableLayoutPanel1.ColumnCount - 1).ToString();

            tableLayoutPanel1.Refresh();

            Console.WriteLine("added a new fan panel");

        }
    }
}
