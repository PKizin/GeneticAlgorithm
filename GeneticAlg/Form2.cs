using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GeneticAlg
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            chart1.Series.Clear();
            chart1.Titles.Add("sqrt");
            chart1.Series.Add("1st individ");
            chart1.Series.Add("2nd individ");
            chart1.Series.Add("3rd individ");
            chart1.Series.Add("4th individ");
            chart1.Series.Add("5th individ");
            chart1.Series.Add("6th individ");
            chart1.Series.Add("7th individ");
            chart1.Series.Add("8th individ");
            chart1.Series[0].Color = Color.Red;
            chart1.Series[1].Color = Color.Orange;
            chart1.Series[2].Color = Color.Yellow;
            chart1.Series[3].Color = Color.Green;
            chart1.Series[4].Color = Color.LightBlue;
            chart1.Series[5].Color = Color.Blue;
            chart1.Series[6].Color = Color.Purple;
            chart1.Series[7].Color = Color.Black;

            chart2.Series.Clear();
            chart2.Titles.Add("F");
            chart2.Series.Add("1st individ");
            chart2.Series.Add("2nd individ");
            chart2.Series.Add("3rd individ");
            chart2.Series.Add("4th individ");
            chart2.Series.Add("5th individ");
            chart2.Series.Add("6th individ");
            chart2.Series.Add("7th individ");
            chart2.Series.Add("8th individ");
            chart2.Series[0].Color = Color.Red;
            chart2.Series[1].Color = Color.Orange;
            chart2.Series[2].Color = Color.Yellow;
            chart2.Series[3].Color = Color.Green;
            chart2.Series[4].Color = Color.LightBlue;
            chart2.Series[5].Color = Color.Blue;
            chart2.Series[6].Color = Color.Purple;
            chart2.Series[7].Color = Color.Black;

            chart3.Series.Clear();
            chart3.Titles.Add("k");
            chart3.Series.Add("1st individ");
            chart3.Series.Add("2nd individ");
            chart3.Series.Add("3rd individ");
            chart3.Series.Add("4th individ");
            chart3.Series.Add("5th individ");
            chart3.Series.Add("6th individ");
            chart3.Series.Add("7th individ");
            chart3.Series.Add("8th individ");
            chart3.Series[0].Color = Color.Red;
            chart3.Series[1].Color = Color.Orange;
            chart3.Series[2].Color = Color.Yellow;
            chart3.Series[3].Color = Color.Green;
            chart3.Series[4].Color = Color.LightBlue;
            chart3.Series[5].Color = Color.Blue;
            chart3.Series[6].Color = Color.Purple;
            chart3.Series[7].Color = Color.Black;
            for (int i = 0; i < 8; i++)
            {
                chart1.Series[i].ChartType = SeriesChartType.Line;
                chart2.Series[i].ChartType = SeriesChartType.Line;
                chart3.Series[i].ChartType = SeriesChartType.Line;
            }
        }

        public void PlotChart1(int i, double p)
        {
            chart1.Series[i].Points.Add(p);
        }

        public void PlotChart2(int i, double p)
        {
            chart2.Series[i].Points.Add(p);
        }

        public void PlotChart3(int i, double p)
        {
            chart3.Series[i].Points.Add(p);
        }
    }
}
