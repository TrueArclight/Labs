using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR7._2OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Результат: ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dataGridView1.RowCount = 15;
            dataGridView1.ColumnCount = 15;
            int[,] matrix = new int[15, 15];
            Random rand = new Random();
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    matrix[i, j] = rand.Next(-50, 50);
                }
            }
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = matrix[i, j].ToString();
                }
            }
            int max = int.MinValue;
            int row = 0;
            for (int i = 0; i < 15; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    row = i;
                }
            }
            for (int j = 0; j < 15; j++)
            {
                textBox1.Text += ' ' + Convert.ToString(matrix[row, j]);
            }

        }
    }
}
