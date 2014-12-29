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
    public partial class Form1 : Form
    {
        public Form2 hwndCharts = new Form2();

        public Form1()
        {
            InitializeComponent();
            UpdateParams();
            UpdateMatrixA();
            ClearTables();
        }

        public void ClearTables()
        {
            int n = Convert.ToInt32(numericUpDown_n.Value);
            int k = Convert.ToInt32(numericUpDown_k.Value);

            ListViewItem lvi;

            // Очищаем матрицу X.
            liX.Clear();
            liX.Columns.Add("", 18);
            for (int i = 1; i < k; i++)
                liX.Columns.Add("", 20);
            for (int i = 0; i < n; i++)
            {
                lvi = new ListViewItem();
                lvi.SubItems[0].Text = "";
                for (int j = 1; j < k; j++)
                    lvi.SubItems.Add("");
                liX.Items.Add(lvi);
            }

            // Очищаем матрицу XT.
            liXT.Clear();
            liXT.Columns.Add("", 18);
            for (int i = 1; i < n; i++)
                liXT.Columns.Add("", 20);
            for (int i = 0; i < k; i++)
            {
                lvi = new ListViewItem();
                lvi.SubItems[0].Text = "";
                for (int j = 1; j < n; j++)
                    lvi.SubItems.Add("");
                liXT.Items.Add(lvi);
            }

            // Очищаем матрицу X*XT.
            liXXT.Clear();
            liXXT.Columns.Add("", 18);
            for (int i = 1; i < n; i++)
                liXXT.Columns.Add("", 20);
            for (int i = 0; i < n; i++)
            {
                lvi = new ListViewItem();
                lvi.SubItems[0].Text = "";
                for (int j = 1; j < n; j++)
                    lvi.SubItems.Add("");
                liXXT.Items.Add(lvi);
            }
        }

        public void MakeTables()
        {
            int n = Convert.ToInt32(numericUpDown_n.Value);
            int nA = Individ.GetN();

            if (n < nA)                 // Если мы уменьшаем n.
            {
                A mat = new A(n);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        mat[i, j] = Individ.GetA()[i, j];

                // Создаем матрицу A.
                liA.Clear();
                liA.Columns.Add("", 18);
                for (int i=1; i<n; i++)
                    liA.Columns.Add("", 20);
                ListViewItem lvi;
                for (int i = 0; i < n; i++)
                {
                    lvi = new ListViewItem();
                    lvi.SubItems[0].Text = mat[i, 0].ToString();
                    for (int j = 1; j < n; j++)
                        lvi.SubItems.Add(mat[i, j].ToString());
                    liA.Items.Add(lvi);
                }
            }
            else if (n > nA)            // Если мы увеличиваем n.
            {
                A mat = new A(nA);
                for (int i = 0; i < nA; i++)
                    for (int j = 0; j < nA; j++)
                        mat[i, j] = Individ.GetA()[i, j];

                // Создаем матрицу A.
                liA.Clear();
                liA.Columns.Add("", 18);
                for (int i = 1; i < n; i++)
                    liA.Columns.Add("", 20);
                ListViewItem lvi;
                for (int i = 0; i < n; i++)
                {
                    lvi = new ListViewItem();
                    if (i < nA)
                    {
                        lvi.SubItems[0].Text = mat[i, 0].ToString();
                        for (int j = 1; j < n; j++)
                        {
                            if (j < nA)
                                lvi.SubItems.Add(mat[i, j].ToString());
                            else
                                lvi.SubItems.Add("0");
                        }
                    }
                    else
                    {
                        lvi.SubItems[0].Text = "0";
                        for (int j = 1; j < n; j++)
                            lvi.SubItems.Add("0");
                    }
                    liA.Items.Add(lvi);
                    liA.Items[i].SubItems[i].Text = "1";
                } 
            }
            
            // Обновляем параметры.
            UpdateParams();
            UpdateMatrixA();

            // Очищаем матрицы результата.
            ClearTables();
        }

        public void UpdateParams()
        {
            int n = Convert.ToInt32(numericUpDown_n.Value);
            int k = Convert.ToInt32(numericUpDown_k.Value);
            double alpha = Convert.ToDouble(numericUpDown_alpha.Value);
            double beta = Convert.ToDouble(numericUpDown_beta.Value);
            int N = Convert.ToInt32(numericUpDown_Npop.Value);
            double Wcross = Convert.ToDouble(numericUpDown_Wcross.Value);
            double Wmut = Convert.ToDouble(numericUpDown_Wmut.Value);
            int Tmax = Convert.ToInt32(numericUpDown_Tmax.Value);
            Individ.UpdateParams(n, k, alpha, beta);
            Population.UpdateParams(N, Wcross, Wmut, Tmax);
        }

        public void UpdateMatrixA()
        {
            int n = Convert.ToInt32(numericUpDown_n.Value);
            int[,] bits = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    bits[i, j] = Convert.ToInt32(liA.Items[i].SubItems[j].Text);
            A A = new A(n, bits);
            Individ.SetA(A);
        }

        public void StartAlgorithm()
        {
            UpdateParams();
            UpdateMatrixA();

            Population pop = new Population();

            hwndCharts.Close();
            if (checkBox1.Checked)
            {
                hwndCharts = new Form2();
                hwndCharts.PlotChart1(0, pop[0].GetSqrt());
                hwndCharts.PlotChart2(0, pop[0].GetF());
                hwndCharts.PlotChart3(0, 1.0 / (Individ.GetAlpha() * pop[0].GetF()));
            }

            if (checkBox2.Checked)
            {
                File.OpenKHROMO();
                File.ClearKHROMO();
                pop.WriteToKHROMO();
            }

            if (checkBox3.Checked)
            {
                File.OpenSQRT();
                File.ClearSQRT();
                pop.WriteToSQRT();
            }

            if (checkBox4.Checked)
            {
                File.OpenF();
                File.ClearF();
                pop.WriteToF();
            }

            if (checkBox5.Checked)
            {
                File.OpenK();
                File.ClearK();
                pop.WriteToK();
            }



            int n = Convert.ToInt32(numericUpDown_n.Value);
            int k = Convert.ToInt32(numericUpDown_k.Value);
            int Tmax = Convert.ToInt32(numericUpDown_Tmax.Value);
            for (int i = 0; i < Tmax; i++)
            {
                pop.CrossingAndMutation();
                if (checkBox1.Checked)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        hwndCharts.PlotChart1(j, pop[j].GetSqrt());
                        hwndCharts.PlotChart2(j, pop[j].GetF());
                        hwndCharts.PlotChart3(j, 1.0 / (Individ.GetAlpha() * pop[j].GetF()));
                    }
                }
                if (checkBox2.Checked)
                    pop.WriteToKHROMO();
                if (checkBox3.Checked)
                    pop.WriteToSQRT();
                if (checkBox4.Checked)
                    pop.WriteToF();
                if (checkBox5.Checked)
                    pop.WriteToK();
            }

            double alpha = Convert.ToDouble(numericUpDown_alpha.Value);
            textBox_f.Text = String.Format("{0:F6}", pop[0].GetF());
            textBox_sqrt.Text = String.Format("{0:F6}", pop[0].GetSqrt());
            textBox_k.Text = String.Format("{0:F6}", 1.0 / (pop[0].GetF() * alpha));

            ClearTables();

            if (Convert.ToDouble(k) == 1.0 / (pop[0].GetF() * alpha))
            {
                MessageBox.Show("Decomposition has been found!", "Success");
                A mat = pop[0].GetKhromo() * pop[0].GetKhromo().Trans();
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < k; j++)
                    {
                        liX.Items[i].SubItems[j].Text = pop[0][i, j].ToString();
                        liXT.Items[j].SubItems[i].Text = pop[0][i, j].ToString();
                    }
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        liXXT.Items[i].SubItems[j].Text = mat[i, j].ToString();
            }
            else
                MessageBox.Show("Algorithm has not found decomposition...", "Failure");

            if (checkBox1.Checked)
                hwndCharts.Show();
            if (checkBox2.Checked)
                File.CloseKHROMO();
            if (checkBox3.Checked)
                File.CloseSQRT();
            if (checkBox4.Checked)
                File.CloseF();
            if (checkBox5.Checked)
                File.CloseK();
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.UtcNow;
            StartAlgorithm();
            DateTime date2 = DateTime.UtcNow;
            int min1 = Convert.ToInt32( date1.ToString("mm") );
            int min2 = Convert.ToInt32( date2.ToString("mm") );
            int sec1 = Convert.ToInt32( date1.ToString("ss") );
            int sec2 = Convert.ToInt32( date2.ToString("ss") );
            int msec1 = Convert.ToInt32( date1.ToString("fff") );
            int msec2 = Convert.ToInt32( date2.ToString("fff") );
            int sec = 60*(min2-min1) + sec2-sec1;
            int msec = msec2 - msec1;
            if (msec < 0)
            {
                msec = 1000 + msec;
                sec--;
            }
            textBox_time.Text = sec.ToString() + "," + msec.ToString();
            textBox_iter.Text = numericUpDown_Tmax.Value.ToString();
            textBox_tpi.Text = String.Format("{0:F3}", Convert.ToDouble(sec.ToString() + "," + msec.ToString()) / Convert.ToDouble(textBox_iter.Text));
        }

        private void numericUpDown_n_ValueChanged(object sender, EventArgs e)
        {
            MakeTables();
        }

        private void numericUpDown_k_ValueChanged(object sender, EventArgs e)
        {
            MakeTables();
        }

        private void button_Random_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(numericUpDown_n.Value);
            int k = Convert.ToInt32(numericUpDown_k.Value);
            double gamma = Convert.ToDouble(numericUpDown_gamma.Value);
            Khromo kh = new Khromo(n, k, gamma);
            A mat = kh * kh.Trans();
            Individ.SetA(mat);

            // Создаем матрицу A.
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    liA.Items[i].SubItems[j].Text = mat[i, j].ToString();
        }


    }
}
