using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LR5._2OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double F(double x)
        {
            return Math.Pow(x, 2) + Math.Tan(5 * x + (-0.8 / x));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Chart myChart = new Chart();
            myChart.Parent = this;
            myChart.Dock = DockStyle.Fill;
            myChart.ChartAreas.Add(new ChartArea("Math functions"));
            Series mySeriesOfPoint = new Series("Func");
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            mySeriesOfPoint.ChartArea = "Math functions";
            for (double x = -1.5; x >= -2.5; x += -0.5)
            {
                mySeriesOfPoint.Points.AddXY(x, F(x));
            }
            myChart.Series.Add(mySeriesOfPoint);
        }
    }
}
