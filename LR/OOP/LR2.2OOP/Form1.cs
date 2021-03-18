using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR2._2OOP
{
    public partial class Form1 : Form
    {
        private double result;
        private double x;
        private double b;
        public Form1()
        {
            InitializeComponent();
            this.x = 0.2;
            this.b = 0.1;
        }

        void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.x * this.b > 0.5 && this.x * this.b < 10) { 
            this.result = Math.Exp(Math.Sinh(x) - Math.Abs(b)); 
            }
            else if(this.x * this.b > 0.1 && this.x * this.b < 0.5) {
                this.result = Math.Sqrt(Math.Sinh(x) + b);
            }
            else
            {
                this.result = 2 * Math.Pow(Math.Sinh(x), 2);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.x * this.b > 0.5 && this.x * this.b < 10)
            {
                this.result = Math.Exp(Math.Pow(x,2) - Math.Abs(b));
            }
            else if (this.x * this.b > 0.1 && this.x * this.b < 0.5)
            {
                this.result = Math.Sqrt(Math.Pow(x, 2) + b);
            }
            else
            {
                this.result = 2 * Math.Pow(Math.Pow(x, 2), 2);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.x * this.b > 0.5 && this.x * this.b < 10)
            {
                this.result = Math.Exp(Math.Exp(x) - Math.Abs(b));
            }
            else if (this.x * this.b > 0.1 && this.x * this.b < 0.5)
            {
                this.result = Math.Sqrt(Math.Exp(x) + b);
            }
            else
            {
                this.result = 2 * Math.Pow(Math.Exp(x), 2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "x: " + this.x + Environment.NewLine+ "b: " + this.b +
                Environment.NewLine + "xb: " + this.x * this.b + Environment.NewLine + "Результат: " + result;
        }
    }
}
