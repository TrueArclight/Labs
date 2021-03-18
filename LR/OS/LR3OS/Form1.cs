using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;

namespace LR3OS
{

    public partial class Form1 : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct MEMORYSTATUSEX
        {
            internal uint dwLength;
            internal uint dwMemoryLoad;
            internal ulong ullTotalPhys;
            internal ulong ullAvailPhys;
            internal ulong ullTotalPageFile;
            internal ulong ullAvailPageFile;
            internal ulong ullTotalVirtual;
            internal ulong ullAvailVirtual;
            internal ulong ullAvailExtendedVirtual;
        }
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MEMORYSTATUSEX statEX = new MEMORYSTATUSEX();
            statEX.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            GlobalMemoryStatusEx(ref statEX);
            //phys
            double totalPhys = (double)statEX.ullTotalPhys / (1024);
            label1.Text = "RAM всего(кб) = " + Math.Round(totalPhys,2).ToString();
            double availPhys = (double)statEX.ullAvailPhys / (1024);
            label2.Text = "RAM свободно(кб) = " + Math.Round(availPhys,2).ToString();
            double memoryLoad = (double)statEX.dwMemoryLoad;
            label3.Text = "Используется " + Math.Round(memoryLoad,2).ToString() + '%';
            //virtual
            double totalVirtual = (double)statEX.ullTotalVirtual / (1024);
            label4.Text = "Виртульной памяти всего(кб) = " + Math.Round(totalVirtual,2).ToString();
            double availVirtual = (double)statEX.ullAvailVirtual / (1024);
            label5.Text = "Вирутальной памяти свободно(кб) = " + Math.Round(availVirtual,2).ToString();
            double memoryLoad2 = (((double)statEX.ullTotalVirtual / 1024) - ((double)statEX.ullAvailVirtual / 1024)) * 100 / ((double)statEX.ullTotalVirtual / 1024);
            label6.Text = "Используется " + Math.Round(memoryLoad2,2).ToString() + '%';
            //PageFile
            double pageFile = (double)statEX.ullTotalPageFile / (1024);
            label7.Text = "Файл подкачки всего(кб) = " + Math.Round(pageFile,2).ToString();
            double pageFile2 = (double)statEX.ullAvailPageFile / (1024);
            label8.Text = "Файл подкачки свободно(кб) = " + Math.Round(pageFile2,2).ToString();
            double memoryLoad3 = (((double)statEX.ullTotalPageFile / 1024) - ((double)statEX.ullAvailPageFile / 1024)) * 100 / ((double)statEX.ullTotalPageFile / 1024);
            label9.Text = "Используется " + Math.Round(memoryLoad3,2).ToString() + '%';
            //diag
            //1
            chart1.Series.Add(new Series("ColumnSeries")
            {
                ChartType = SeriesChartType.Pie
            });
            double[] yValues = { memoryLoad, 100 - memoryLoad };
            string[] xValues = { "Загрузка " + Math.Round(memoryLoad,3).ToString() + '%', "Доступно " + Math.Round((100 - memoryLoad),3).ToString() + '%' };
            chart1.Series["ColumnSeries"].IsValueShownAsLabel = true;
            chart1.Series["ColumnSeries"].Points.DataBindXY(xValues, yValues);
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            //2
            chart2.Series.Add(new Series("ColumnSeries2")
            {
                ChartType = SeriesChartType.Pie
            });
            double[] yValues2 = { Math.Round(memoryLoad2, 2), Math.Round(100 - memoryLoad2, 2) };
            string[] xValues2 = { "Загрузка " + Math.Round(memoryLoad2, 2).ToString() + '%', "Доступно " + Math.Round(100 - memoryLoad2, 2).ToString() + '%' };
            chart2.Series["ColumnSeries2"].IsValueShownAsLabel = true;
            chart2.Series["ColumnSeries2"].Points.DataBindXY(xValues2, yValues2);
            chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
            //3
            chart3.Series.Add(new Series("ColumnSeries3")
            {
                ChartType = SeriesChartType.Pie
            });
            double[] yValues3 = { Math.Round(memoryLoad3, 2), Math.Round(100 - memoryLoad3, 2) };
            string[] xValues3 = { "Загрузка " + Math.Round(memoryLoad3, 2).ToString() + '%', "Доступно " + Math.Round(100 - memoryLoad3, 2).ToString() + '%' };
            chart3.Series["ColumnSeries3"].IsValueShownAsLabel = true;
            chart3.Series["ColumnSeries3"].Points.DataBindXY(xValues3, yValues3);
            chart3.ChartAreas[0].Area3DStyle.Enable3D = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 addRec = new Form2();
            addRec.Owner = this;
            addRec.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            MEMORYSTATUSEX statEX = new MEMORYSTATUSEX();
            statEX.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            GlobalMemoryStatusEx(ref statEX);
            //phys
            double totalPhys = (double)statEX.ullTotalPhys / (1024);
            label1.Text = "RAM всего(кб) = " + Math.Round(totalPhys, 2).ToString();
            double availPhys = (double)statEX.ullAvailPhys / (1024);
            label2.Text = "RAM свободно(кб) = " + Math.Round(availPhys, 2).ToString();
            double memoryLoad = (double)statEX.dwMemoryLoad;
            label3.Text = "Используется " + Math.Round(memoryLoad, 2).ToString() + '%';
            //virtual
            double totalVirtual = (double)statEX.ullTotalVirtual / (1024);
            label4.Text = "Виртульной памяти всего(кб) = " + Math.Round(totalVirtual, 2).ToString();
            double availVirtual = (double)statEX.ullAvailVirtual / (1024);
            label5.Text = "Вирутальной памяти свободно(кб) = " + Math.Round(availVirtual, 2).ToString();
            double memoryLoad2 = (((double)statEX.ullTotalVirtual / 1024) - ((double)statEX.ullAvailVirtual / 1024)) * 100 / ((double)statEX.ullTotalVirtual / 1024);
            label6.Text = "Используется " + Math.Round(memoryLoad2, 2).ToString() + '%';
            //PageFile
            double pageFile = (double)statEX.ullTotalPageFile / (1024);
            label7.Text = "Файл подкачки всего(кб) = " + Math.Round(pageFile, 2).ToString();
            double pageFile2 = (double)statEX.ullAvailPageFile / (1024);
            label8.Text = "Файл подкачки свободно(кб) = " + Math.Round(pageFile2, 2).ToString();
            double memoryLoad3 = (((double)statEX.ullTotalPageFile / 1024) - ((double)statEX.ullAvailPageFile / 1024)) * 100 / ((double)statEX.ullTotalPageFile / 1024);
            label9.Text = "Используется " + Math.Round(memoryLoad3, 2).ToString() + '%';
            //diag
            //1
            double[] yValues = { memoryLoad, 100 - memoryLoad };
            string[] xValues = { "Загрузка " + Math.Round(memoryLoad, 3).ToString() + '%', "Доступно " + Math.Round((100 - memoryLoad), 3).ToString() + '%' };
            chart1.Series["ColumnSeries"].IsValueShownAsLabel = true;
            chart1.Series["ColumnSeries"].Points.DataBindXY(xValues, yValues);
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            //2
            double[] yValues2 = { Math.Round(memoryLoad2, 2), Math.Round(100 - memoryLoad2, 2) };
            string[] xValues2 = { "Загрузка " + Math.Round(memoryLoad2, 2).ToString() + '%', "Доступно " + Math.Round(100 - memoryLoad2, 2).ToString() + '%' };
            chart2.Series["ColumnSeries2"].IsValueShownAsLabel = true;
            chart2.Series["ColumnSeries2"].Points.DataBindXY(xValues2, yValues2);
            chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
            //3
            double[] yValues3 = { Math.Round(memoryLoad3, 2), Math.Round(100 - memoryLoad3, 2) };
            string[] xValues3 = { "Загрузка " + Math.Round(memoryLoad3, 2).ToString() + '%', "Доступно " + Math.Round(100 - memoryLoad3, 2).ToString() + '%' };
            chart3.Series["ColumnSeries3"].IsValueShownAsLabel = true;
            chart3.Series["ColumnSeries3"].Points.DataBindXY(xValues3, yValues3);
            chart3.ChartAreas[0].Area3DStyle.Enable3D = true;
        }
    }
}
