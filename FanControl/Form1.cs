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
        fanPanel[] myFanPanels = new fanPanel[16];

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < myFanPanels.Length; i++)
            {
                myFanPanels[i] = new fanPanel(myFtdiDevice);
                myFanPanels[i].I2C_slaveAddressLabel.Text = "0x" + (i<<3).ToString("X2");
                myFanPanels[i].fanNameLabel.Text = "FAN " + i.ToString();

                tableLayoutPanel1.ColumnCount = i;
                tableLayoutPanel1.Controls.Add(myFanPanels[i], i, 0);
                myFanPanels[i].Hide();
            }

            myFanPanels[0].initialize();
            if (myFanPanels[0].deviceInit)
            {

            }
            else
            {
                MessageBox.Show("could not find FTDI device! Closing.");
                this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            checkHardwareChanges();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            checkHardwareChanges();
            timer1.Start();

        }

        private void checkHardwareChanges()
        {
            bool[] devices_present = myFanPanels[0].ping();

            for (int i = 0; i < myFanPanels.Length; i++)
            {
                Console.WriteLine("i: " + i + ", devices_present[i]: " + devices_present[i]);
                if (devices_present[i])
                {
                    myFanPanels[i].Show();
                }
                else
                {
                    myFanPanels[i].Hide();
                }
            }
        }

    }
}
