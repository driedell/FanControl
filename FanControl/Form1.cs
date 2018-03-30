using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FTD2XX_NET;

namespace FanControl
{
    public partial class Form1 : Form
    {
        // Create new instance of the FTDI device class
        FTDI myFtdiDevice = new FTDI();
        fanPanel myFanPanel;

        public Form1()
        {
            InitializeComponent();

            myFanPanel = new fanPanel(tableLayoutPanel1, tableLayoutPanel1.ColumnCount - 1, myFtdiDevice);
            myFanPanel.initialize();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //tableLayoutPanel1.ColumnCount++;
            //fanPanel myFanPanel = new fanPanel(tableLayoutPanel1, tableLayoutPanel1.ColumnCount-1, myFtdiDevice);

            //Console.WriteLine("added a new fan panel");

            // Find I2C Devices

            bool[] devices = myFanPanel.ping();

            foreach (bool device in devices)
            {
                Console.WriteLine(device);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
