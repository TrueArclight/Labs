using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LR11OOP
{
    public partial class Form1 : Form
    {
        private string fileName;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;  
            }
            textBox1.Text = fileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            FileStream fs = new FileStream(fileName, FileMode.Open);
            StreamWriter sw = new StreamWriter(fs);
            int k = 0;
            char c;
            fs.Seek(0, SeekOrigin.Begin);
            int x;
            do
            {
                x = fs.ReadByte();
                if (x != -1)
                {
                    c = (char)x;
                    k++;
                    if (c == '\n')
                    {
                        long pos = fs.Position;
                        fs.Seek(0, SeekOrigin.End);
                        fs.Seek(pos, SeekOrigin.Begin);
                    }
                }
            } while (x != -1);
            sw.Close();
            fs.Close();
            
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (sr.Peek() >= 0)
                {
                    string s = sr.ReadLine();
                    string[] arr = s.Split(' ');
                    foreach (string asd in arr)
                    {
                        richTextBox1.Text += asd + ' ';

                    }
                    richTextBox1.Text += '\n';
                }
            }
            richTextBox1.Text += ("[" + k + "]");

            using (StreamReader sr = new StreamReader(fileName))
            {
                while (sr.Peek() >= 0)
                {
                    string s = sr.ReadLine();
                    string[] arr = s.Split(' ');
                    IEnumerable<string> query =  arr.OrderBy(a=>a.Length);
                    foreach (string asd in query)
                    {
                        richTextBox2.Text += asd + ' ';
                       
                    }
                     richTextBox2.Text += '\n';
                }
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            textBox1.Text = "";
            richTextBox2.Text = "";
        }
    }
}
