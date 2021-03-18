using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace OOPLR4
{
    public partial class Form1 : Form
    {
        int counter = 0;
        int counter1 = 0;
        int counter2 = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Random random = new Random();
            int a, c;
            a = random.Next(20, 400);
            c = random.Next(20, 400);
            Button b = new Button();
            counter++;
            b.Location = new Point(a,c);
            b.Text = "Кнопка " + counter.ToString() ;
            Controls.Add(b);
            b.Click += new System.EventHandler(button1_Click_1);
            TextBox v = new TextBox();
            v.Location = new Point(100, 20);
            v.Click += new System.EventHandler(button1_Click_1);
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

            Random random = new Random();
            int a, c;
            a = random.Next(20, 400);
            c = random.Next(20, 400);
            Label lbl1 = new Label();
            counter1++;
            lbl1.Location = new Point(a, c);
            lbl1.Text = "Метка " + counter1.ToString();
            Controls.Add(lbl1);
            lbl1.Click += new System.EventHandler(label1_Click_1);
        }

        private void textBox1_Click_1(object sender, EventArgs e)
        {
            Random random = new Random();
            int a, c;
            a = random.Next(20, 400);
            c = random.Next(20, 400);
            TextBox txt1 = new TextBox();
            counter2++;
            txt1.Text = counter2.ToString();
            txt1.Location = new Point(a, c);
            txt1.Name = "name";
            Controls.Add(txt1);
            txt1.Click += new System.EventHandler(textBox1_Click_1);
        }
    }
}
