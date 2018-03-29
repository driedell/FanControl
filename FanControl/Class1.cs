using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FanControl
{
    class MyButton : System.Windows.Forms.Control
    {


        public MyButton(Form myForm)
        {
            this.myButton1 = new Button();


            // 
            // button1
            // 
            this.myButton1.Location = new System.Drawing.Point(100, 100);
            this.myButton1.Name = "myButton";
            this.myButton1.Size = new System.Drawing.Size(75, 23);
            this.myButton1.TabIndex = 6;
            this.myButton1.Text = "myButton1";
            this.myButton1.UseVisualStyleBackColor = true;
            this.myButton1.Click += new System.EventHandler(this.button1_Click);


            myForm.Controls.Add(myButton1);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("clicked the button");
        }

        public System.Windows.Forms.Button myButton1;

    }
}
