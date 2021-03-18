using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;

namespace OOPLR3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog.FileName, Encoding.Default);
                richTextBox1.Text = reader.ReadToEnd();
                reader.Close();
            }
            openFileDialog.Dispose();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog saveFileDialog = new OpenFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
               StreamWriter writer = new StreamWriter(saveFileDialog.FileName);
               for(int i = 0; i < listBox2.Items.Count; i++)
                {
                    writer.WriteLine((string)listBox2.Items[i]);
                }
                writer.Close();
            }
            saveFileDialog.Dispose();

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.BeginUpdate();
            string[] strings = richTextBox1.Text.Split(new char[] { '\n', '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string s in strings)
            {
                string Str = s.Trim();
                if (Str == String.Empty) continue;
                if (radioButton1.Checked) listBox1.Items.Add(Str);
                if(radioButton2.Checked)
                {
                    if (Regex.IsMatch(Str, @"\d")) listBox1.Items.Add(Str);
                }
                if (radioButton3.Checked)
                {
                    if (Regex.IsMatch(Str, @"\D")) listBox1.Items.Add(Str);
                }
            }
            listBox1.EndUpdate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            richTextBox1.Text = "";
            radioButton1.Checked = true;
            checkBox1.Checked = true;
            checkBox2.Checked = false;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            string Find = textBox1.Text;
            if(checkBox1.Checked)
            {
                foreach(string s in listBox1.Items)
                {
                    if (s.Contains(Find)) listBox3.Items.Add(s);
                }
            }
            if (checkBox2.Checked)
            {
                foreach (string s in listBox2.Items)
                {
                    if (s.Contains(Find)) listBox3.Items.Add(s);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 AddRec = new Form2();
            AddRec.Owner = this;
            AddRec.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i)) listBox1.Items.RemoveAt(i);
            }
            for (int i = listBox2.Items.Count - 1; i >= 0; i--)
            {
                if (listBox2.GetSelected(i)) listBox2.Items.RemoveAt(i);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Sorted = false;
            if(comboBox1.SelectedIndex == 0)
            {
                listBox1.Sorted = true;
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                ArrayList list = new ArrayList();
                foreach( object L in listBox1.Items)
                {
                    list.Add(L);
                }
                list.Sort();
                list.Reverse();
                listBox1.Items.Clear();
                foreach(object L in list)
                {
                    listBox1.Items.Add(L);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i))
                {
                    listBox2.Items.Add(listBox1.Items[i].ToString());
                    listBox1.Items.RemoveAt(i);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(listBox1.Items);
            listBox1.Items.Clear();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(listBox2.Items);
            listBox2.Items.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            for (int i = listBox2.Items.Count - 1; i >= 0; i--)
            {
                if (listBox2.GetSelected(i))
                {
                    listBox1.Items.Add(listBox2.Items[i].ToString());
                    listBox2.Items.RemoveAt(i);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox2.Sorted = false;
            if (comboBox2.SelectedIndex == 0)
            {
                listBox2.Sorted = true ;
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                ArrayList list = new ArrayList();
                foreach (object L in listBox2.Items)
                {
                    list.Add(L);
                }
                list.Sort();
                list.Reverse();
                listBox2.Items.Clear();
                foreach (object L in list)
                {
                    listBox2.Items.Add(L);
                }
            }
        }
    }
}
