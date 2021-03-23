using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR6OOP
{
    public partial class Form1 : Form
    {
        private MyArray arr;
        private double[] array = new double[25];
        class MyArray
        {
            public int[,] _data;
            public MyArray(int m, int n)
            {
                _data = new int[m, n];
            }
            public MyArray(MyArray other)
            {
                _data = other._data;
            }
            public int GetLength(int d)
            {
                return _data.GetLength(d);
            }
            public int GetValue(int i1, int i2)
            {
                return _data[i1, i2];
            }
            public void SetValue(int i1, int i2, int val)
            {
                _data[i1, i2] = val;
            }
            public static MyArray operator -(MyArray originalArray, int columnToRemove)
            {
                int[,] tempArr = new int[originalArray._data.GetLength(0), originalArray._data.GetLength(1)];

                for (int i = 0, j = 0; i < originalArray.GetLength(0); i++)
                {
                    for (int k = 0, u = 0; k < originalArray._data.GetLength(1); k++)
                    {
                        if (k < columnToRemove)
                            continue;

                        tempArr[j, u] = originalArray._data[i, k];
                        u++;
                    }
                    j++;
                }
                MyArray result = new MyArray(tempArr.GetLength(0), tempArr.GetLength(1) - columnToRemove);
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result._data[i, j] = tempArr[i, j];
                    }
                }
                return result;
            }
        }
        public Form1()
        {
            InitializeComponent(); 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            int m = Int32.Parse(textBox2.Text);
            arr = new MyArray(m, m);
            int min = 10, max = 99;
            Random r = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr.SetValue(i, j, r.Next(min, max));
                    richTextBox1.Text += String.Format("{0,3}", arr.GetValue(i, j));
                }
                richTextBox1.Text += '\n';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int colsToDel = Int32.Parse(textBox1.Text);
            if (colsToDel <= arr.GetLength(1) || colsToDel < 0)
            {
               richTextBox2.Text = "";
               arr -= colsToDel;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        richTextBox2.Text += String.Format("{0,3}", arr.GetValue(i, j));
                    }
                    richTextBox2.Text += '\n';
                }
            }
            else
            {
                richTextBox2.Text = "Неверное количество столбцов для удаления";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            double min = -1.4, max = 6.4;
            Random r = new Random();
            for (int i = 0; i < 25; i++)
            {
                array[i] = r.NextDouble() * (max-min) + min;
                listBox1.Items.Add("A["+i+"] = "+array[i]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int counter = 0;
            int cnt = 0;
            for(int i = 0; i< array.Length; i++)
            {
                if(array[i] < 0)
                {
                    counter++;
                }
                if( array[i] >= 1 && array[i] <= 2)
                {
                    cnt++;
                }
            }
            richTextBox3.Text = String.Format("Число отрицательных элементов = {0}\nЧисло членов принадлежащих отрезку [1,2] = {1}",counter,cnt);
        }
    }
}
