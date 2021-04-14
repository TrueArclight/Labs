using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR7OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int cnt;
        private double[] a;
        private double[] b;
        private double[] c;
        private void Form1_Load(object sender, EventArgs e)
        {
            cnt = 0;
            for (double x = -2; x <= 4; x += 0.3)
            {
                cnt++;
            }
            a = new double[cnt];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnt = 0;
            try
            {
                for (double x = -2; x <= 4; x += 0.3)
                {
                    if (1 / (x + 1) <= 0)
                    {
                        a[cnt] = 0;
                        listBox1.Items.Add(a[cnt]);
                        cnt++;
                    }
                    else
                    {
                        a[cnt] = Math.Log(1 / (x + 1));
                        listBox1.Items.Add(a[cnt]);
                        cnt++;
                    }
                }
            }
            catch(Exception)
            {
                label1.Text += "\nWrong log number";
            }
        }

    }

}

