using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace GeneticAlg
{
    class File
    {
        public static Excel.Application xlAppKHROMO;
        public static Excel.Workbook xlWorkbookKHROMO;
        public static Excel.Worksheet xlWorksheetKHROMO;
        public static Excel.Range xlRangeKHROMO;

        public static Excel.Application xlAppSQRT;
        public static Excel.Workbook xlWorkbookSQRT;
        public static Excel.Worksheet xlWorksheetSQRT;
        public static Excel.Range xlRangeSQRT;

        public static Excel.Application xlAppF;
        public static Excel.Workbook xlWorkbookF;
        public static Excel.Worksheet xlWorksheetF;
        public static Excel.Range xlRangeF;

        public static Excel.Application xlAppK;
        public static Excel.Workbook xlWorkbookK;
        public static Excel.Worksheet xlWorksheetK;
        public static Excel.Range xlRangeK;

        public static void OpenKHROMO()
        {
            xlAppKHROMO = new Excel.Application();
            string dir = Directory.GetCurrentDirectory();
            xlWorkbookKHROMO = xlAppKHROMO.Workbooks.Add();
            //xlWorkbookKHROMO = xlAppKHROMO.Workbooks.Open(Filename: dir + "\\PopulationF.xls", ReadOnly: false);
            xlWorksheetKHROMO = (Excel.Worksheet)xlWorkbookKHROMO.Sheets[1];
            xlRangeKHROMO = xlWorksheetKHROMO.UsedRange;
            xlRangeKHROMO.EntireColumn.ColumnWidth = 2;
        }
        public static void OpenSQRT()
        {
            xlAppSQRT = new Excel.Application();
            string dir = Directory.GetCurrentDirectory();
            xlWorkbookSQRT = xlAppSQRT.Workbooks.Add();
            //xlWorkbookSQRT = xlAppSQRT.Workbooks.Open(Filename: dir + "\\PopulationF.xls", ReadOnly: false);
            xlWorksheetSQRT = (Excel.Worksheet)xlWorkbookSQRT.Sheets[1];
            xlRangeSQRT = xlWorksheetSQRT.UsedRange;
        }
        public static void OpenF()
        {
            xlAppF = new Excel.Application();
            string dir = Directory.GetCurrentDirectory();
            xlWorkbookF = xlAppF.Workbooks.Add();
            //xlWorkbookF = xlAppF.Workbooks.Open(Filename: dir + "\\PopulationF.xls", ReadOnly: false);
            xlWorksheetF = (Excel.Worksheet)xlWorkbookF.Sheets[1];
            xlRangeF = xlWorksheetF.UsedRange;
        }
        public static void OpenK()
        {
            xlAppK = new Excel.Application();
            string dir = Directory.GetCurrentDirectory();
            xlWorkbookK = xlAppK.Workbooks.Add();
            //xlWorkbookK = xlAppK.Workbooks.Open(Filename: dir + "\\PopulationF.xls", ReadOnly: false);
            xlWorksheetK = (Excel.Worksheet)xlWorkbookK.Sheets[1];
            xlRangeK = xlWorksheetK.UsedRange;
        }

        public static void ClearKHROMO()
        {
            xlWorksheetKHROMO.Cells.ClearContents();
        }
        public static void ClearSQRT()
        {
            xlWorksheetSQRT.Cells.ClearContents();
        }
        public static void ClearF()
        {
            xlWorksheetF.Cells.ClearContents();
        }
        public static void ClearK()
        {
            xlWorksheetK.Cells.ClearContents();
        }

        public static void CloseKHROMO()
        {
            string dir = Directory.GetCurrentDirectory();
            xlWorkbookKHROMO.SaveAs(Filename: dir + "\\khromo.xls"); ;
            xlWorkbookKHROMO.Close();
            xlAppKHROMO.Quit();

            Marshal.ReleaseComObject(xlAppKHROMO);

            xlAppKHROMO = new Excel.Application();
            xlWorkbookKHROMO = xlAppKHROMO.Workbooks.Open(Filename: dir + "\\khromo.xls", ReadOnly: false);
            xlWorksheetKHROMO = (Excel.Worksheet)xlWorkbookKHROMO.Sheets[1];
            xlRangeKHROMO = xlWorksheetKHROMO.UsedRange;
            xlRangeKHROMO.EntireColumn.ColumnWidth = 2;
            xlWorkbookKHROMO.Save(); ;
            xlWorkbookKHROMO.Close();
            xlAppKHROMO.Quit();

            Marshal.ReleaseComObject(xlAppKHROMO);
        }
        public static void CloseSQRT()
        {
            string dir = Directory.GetCurrentDirectory();
            xlWorkbookSQRT.SaveAs(Filename: dir + "\\sqrt.xls"); ;
            xlWorkbookSQRT.Close();
            xlAppSQRT.Quit();

            Marshal.ReleaseComObject(xlAppSQRT);
        }
        public static void CloseF()
        {
            string dir = Directory.GetCurrentDirectory();
            xlWorkbookF.SaveAs(Filename: dir + "\\f.xls"); ;
            xlWorkbookF.Close();
            xlAppF.Quit();

            Marshal.ReleaseComObject(xlAppF);
        }
        public static void CloseK()
        {
            string dir = Directory.GetCurrentDirectory();
            xlWorkbookK.SaveAs(Filename: dir + "\\k.xls"); ;
            xlWorkbookK.Close();
            xlAppK.Quit();

            Marshal.ReleaseComObject(xlAppK);
        }
    }


    class Rand
    {
        public static Random rnd = new Random();
    }


    class A
    {
        private int mN;                             // Размерность матрицы A.
        private int[,] mBits;                       // Биты матрицы A.

        // Конструкторы.
        public A() { mN = 0; }
        public A(int n)
        {
            mN = n;
            mBits = new int[mN,mN];
            for (int i=0; i<mN; i++)
                for (int j=0; j<mN; j++)
                    mBits[i,j] = Rand.rnd.Next(0, 2);
        }
        public A(int n, int[,] bits)
        {
            mN = n;
            mBits = new int[mN, mN];
            for (int i=0; i<mN; i++)
                for (int j=0; j<mN; j++)
                    mBits[i,j] = bits[i,j];
        }

        // Доступ.
        public int GetN() { return mN; }
        public int[,] GetBits() { return mBits; }
        public void SetData(int n, int[,] bits)
        {
            mN = n;
            mBits = new int[mN, mN];
            for (int i=0; i<mN; i++)
                for (int j=0; j<mN; j++)
                    mBits[i,j] = bits[i,j];
        }
        public int this[int i, int j]
        {
            get { return mBits[i, j]; }
            set { mBits[i, j] = value; }
        }

        // Дебаг.
        public void ShowA()
        {
            string msg = "";
            for (int i=0; i<mN; i++)
                for (int j=0; j<mN; j++)
                    if (j != mN-1)
                        msg += mBits[i,j].ToString() + " ";
                    else
                        msg += mBits[i,j].ToString() + "\n";
            MessageBox.Show(msg, "Матрица A");
        }
    }


    class Gen
    {
        private int mN;                             // Длина гена.
        private int[] mBits;                        // Биты гена.
        
        // Конструкторы.
        public Gen() { mN = 0; }
        public Gen(int n)
        {
            mN = n;
            mBits = new int[mN];
            for (int i=0; i<mN; i++)
                mBits[i] = Rand.rnd.Next(0, 2);
        }
        public Gen(int n, double gamma)
        {
            mN = n;
            mBits = new int[mN];
            for (int i = 0; i < mN; i++)
            {
                mBits[i] = Rand.rnd.Next(0, 2);
                if (gamma < 0.5)
                {
                    int prop = Convert.ToInt32(2 * gamma * 100);
                    int val = Rand.rnd.Next(0, 101);
                    if ((mBits[i] == 1) && (val >= prop))
                        mBits[i] = 0;
                }
                else if (gamma > 0.5)
                {
                    int prop = Convert.ToInt32(2 * (gamma - 0.5) * 100);
                    int val = Rand.rnd.Next(0, 101);
                    if ((mBits[i] == 0) && (val <= prop))
                        mBits[i] = 1;
                }
            }
        }
        public Gen(int n, int[] bits)
        {
            mN = n;
            mBits = new int[mN];
            for (int i=0; i<mN; i++)
                mBits[i] = bits[i];
        }

        // Доступ.
        public int GetN() { return mN; }
        public int[] GetBits() { return mBits; }
        public void SetData(int n, int[] bits) 
        {
            mN = n;
            mBits = new int[mN];
            for (int i=0; i<mN; i++)
                mBits[i] = bits[i];
        }
        public int this[int i]
        {
            get { return mBits[i]; }
            set { mBits[i] = value; }
        }

        // Дебаг.
        public void ShowGen()
        {
            string msg = "";
            for (int i = 0; i < mN; i++)
                if (i != mN - 1)
                    msg += mBits[i].ToString() + "\n";
                else
                    msg += mBits[i].ToString();
            MessageBox.Show(msg, "Ген");
        }
    }


    class Khromo
    {
        private int mN;             // Длина гена в хромосоме.
        private int mK;             // Количество ген в хромосоме.
        private Gen[] mGens;        // Гены хромосомы.

        // Конструкторы.
        public Khromo() { mN = 0; mK = 0; }
        public Khromo(int n, int k)
        {
            mN = n;
            mK = k;
            mGens = new Gen[mK];
            for (int i = 0; i < mK; i++)
                mGens[i] = new Gen(mN);
        }
        public Khromo(int n, int k, Gen[] gens)
        {
            mN = n;
            mK = k;
            mGens = new Gen[mK];
            for (int i = 0; i < mK; i++)
                mGens[i] = gens[i];
        }
        public Khromo(int n, int k, double gamma)
        {
            mN = n;
            mK = k;
            mGens = new Gen[mK];
            for (int i = 0; i < mK; i++)
                mGens[i] = new Gen(mN, gamma);
        }

        // Доступ.
        public int GetN() { return mN; }
        public int GetK() { return mK; }
        public Gen[] GetGens() { return mGens; }
        public void SetData(int n, int k, Gen[] gens)
        {
            mN = n;
            mK = k;
            mGens = new Gen[mK];
            for (int i = 0; i < mK; i++)
                mGens[i] = gens[i];
        }
        public int this[int i, int j]
        {
            get { return mGens[j][i]; }
            set { mGens[j][i] = value; }
        }

        // Операторы.
        public static A operator* (Khromo kh1, Khromo kh2)
        {
            int n = kh1.GetN();
            int m = kh1.GetK();
            A mat = new A(n);
            for (int i=0; i<n; i++)
                for (int j=0; j<n; j++)
                {
                    mat[i,j] = 0;
                    for (int k=0; k<m; k++)
                        mat[i,j] += kh1[i,k]*kh2[k,j];
                    if (mat[i, j] > 1)
                        mat[i, j] = 1;
                }
            return mat;
        }

        // Дебаг.
        public void ShowKhromo()
        {
            string msg = "";
            for (int i = 0; i < mN; i++)
                for (int j = 0; j < mK; j++)
                    if (j != mK - 1)
                        msg += mGens[j][i].ToString() + " ";
                    else
                        msg += mGens[j][i].ToString() + "\n";
            MessageBox.Show(msg, "Хромосома");
        }

        // Транспонирование.
        public Khromo Trans()
        {
            Gen[] gens = new Gen[mN];
            for (int i=0; i<mN; i++)
                gens[i] = new Gen(mK);
            for (int i=0; i<mN; i++)
                for (int j=0; j<mK; j++)
                    gens[i][j] = mGens[j][i];
            return new Khromo(mK, mN, gens);
        }

        // Деление.
        public Khromo[] Split(int k)
        {
            Khromo kh1 = new Khromo(mN, k+1);
            Khromo kh2 = new Khromo(mN, mK-k-1);
            for (int i=0; i<mN; i++)
                for (int j=0; j<mK; j++)
                    if (j <= k)
                        kh1[i,j] = mGens[j][i];
                    else
                        kh2[i,j-k-1] = mGens[j][i];
            Khromo[] kh = new Khromo[2];
            kh[0] = kh1;
            kh[1] = kh2;
            return kh;
        }

        // Объединение.
        public static Khromo Assemble(Khromo kh1, Khromo kh2)
        {
            int n = Individ.GetN();
            int k = Individ.GetK();
            int div = kh1.GetK() - 1;
            Khromo kh = new Khromo(n, k);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < k; j++)
                    if (j <= div)
                        kh[i, j] = kh1[i, j];
                    else
                        kh[i, j] = kh2[i, j - div - 1];
            return kh;
        }

    }


    class Individ
    {
        private Khromo mKh;             // Хромосома особи.
        private double mF;              // Фитнес-функция особи.
        private double mSqrt;           // Корень при коэфф. beta.
        private static double alpha;
        private static double beta;
        private static int n;
        private static int k;
        private static A A;

        // Конструкторы.
        public Individ()
        {
            mKh = new Khromo(n, k);
            CalculateSQRT();
            CalculateF();
        }
        public Individ(Khromo kh)
        {
            mKh = kh;
            CalculateSQRT();
            CalculateF();
        }

        // Доступ.
        public Khromo GetKhromo() { return mKh; }
        public double GetF() { return mF; }
        public double GetSqrt() { return mSqrt; }
        public static double GetAlpha() { return alpha; }
        public static double GetBeta() { return beta; }
        public static int GetN() { return n; }
        public static int GetK() { return k; }
        public static A GetA() { return A; }
        public void SetKhromo(Khromo kh) { mKh = kh; }
        public static void SetAlpha(double alp) { alpha = alp; }
        public static void SetBeta(double bet) { beta = bet; }
        public static void SetN(int n1) { n = n1; }
        public static void SetK(int k1) { k = k1; }
        public static void SetA(A A1) { A = A1; }
        public int this[int i, int j]
        {
            get { return mKh[i,j]; }
            set { mKh[i,j] = value; }
        }
        public static void UpdateParams(int n1, int k1, double alpha1, double beta1)
        {
            n = n1;
            k = k1;
            alpha = alpha1;
            beta = beta1;
        }

        // Дебаг.
        public void ShowInd()
        {
            string msg = "";
            for (int i = 0; i < n; i++)
                for (int j = 0; j < k; j++)
                    if (j != k - 1)
                        msg += (mKh.GetGens())[j][i].ToString() + " ";
                    else
                        msg += (mKh.GetGens())[j][i].ToString() + "\n";
            msg += "\n" + "SQRT = " + mSqrt.ToString();
            msg += "\n" + "F = " + mF.ToString();
            MessageBox.Show(msg, "Особь");
        }

        // Подсчет Sqrt.
        public void CalculateSQRT()
        {
            double sum = 0.0;
            Khromo kh1 = mKh;
            Khromo kh2 = mKh.Trans();
            A mat = kh1 * kh2;
            for (int i=0; i<n; i++)
                for (int j=0; j<n; j++)
                    sum += Math.Pow(A[i,j] - mat[i,j], 2);
            mSqrt = Math.Sqrt(sum);
        }
           
        // Подсчет F.
        public void CalculateF()
        {
            mF = 1.0 / (alpha * k + beta * mSqrt);
        }

    }


    class Population
    {
        private Individ[] mInds;        // Особи популяции.
        private static int N;           // Размер популяции.
        private static double Wcross;   // Вероятность скрещивания.
        private static double Wmut;     // Вероятность мутации.
        private static int Tmax;        // Предельное число итераций.
        private static int Tcur;        // Текущая итерация.

        // Конструкторы.
        public Population()
        {
            mInds = new Individ[N];
            for (int i = 0; i < N; i++)
                mInds[i] = new Individ();
            Sort();
        }

        // Доступ.
        public Individ[] GetInds() { return mInds; }
        public static int GetN() { return N; }
        public static double GetWcross() { return Wcross; }
        public static double GetWmut() { return Wmut; }
        public static int GetTmax() { return Tmax; }
        public static int GetTcur() { return Tcur; }
        public void SetData(Individ[] inds)
        {
            mInds = new Individ[N];
            for (int i = 0; i < N; i++)
                mInds[i] = inds[i];
        }
        public static void SetN(int n) { N = n; }
        public static void SetWcross(double w1) { Wcross = w1; }
        public static void SetWmut(double w2) { Wmut = w2; }
        public static void SetTmax(int t) { Tmax = t; }
        public static void SetTcur(int t) { Tcur = t; }
        public Individ this[int i]
        {
            get { return mInds[i]; }
            set { mInds[i] = value; }
        }
        public static void UpdateParams(int N1, double Wcross1, double Wmut1, int Tmax1)
        {
            N = N1;
            Wcross = Wcross1;
            Wmut = Wmut1;
            Tmax = Tmax1;
            Tcur = 0;
        }


        // Дебаг.
        public void ShowPopulation()
        {
            string msg = "";
            int i = 0;
            while (i < N)
            {
                for (int j = 0; j < 20; j++)
                {
                    double val = mInds[i].GetF();
                    string str = String.Format("{0:F12}", val);
                    msg += "F = " + str + "\n";
                    i++;
                    if (i >= Math.Min(20,N))
                    {
                        MessageBox.Show(msg, "Популяция");
                        return;
                    }
                }
                MessageBox.Show(msg, "Популяция");
                msg = "";
            }
        }
        public void ShowInds()
        {
            for (int i = 0; i < mInds.Length; i++)
                mInds[i].ShowInd();
        }
        public void WriteToKHROMO()
        {
            for (int i = 0; i < Individ.GetN(); i++)
            {
                for (int j = 0; j < Population.GetN(); j++)
                {
                    for (int k = 0; k < Individ.GetK(); k++)
                        File.xlWorksheetKHROMO.Cells[i + Tcur*(Individ.GetN()+1) + 1, k + j * (Individ.GetK() + 1) + 1] = mInds[j][i, k];
                }
            }
        }
        public void WriteToSQRT()
        {
            for (int i = 0; i < Population.GetN(); i++)
                File.xlWorksheetSQRT.Cells[Tcur + 1, i + 1] = mInds[i].GetSqrt();
        }
        public void WriteToF()
        {
            for (int i = 0; i < Population.GetN(); i++)
                File.xlWorksheetF.Cells[Tcur+1, i+1] = mInds[i].GetF();
        }
        public void WriteToK()
        {
            for (int i = 0; i < Population.GetN(); i++)
                File.xlWorksheetK.Cells[Tcur + 1, i + 1] = 1.0 / (Individ.GetAlpha() * mInds[i].GetF());
        }

        // Добавление индивида в популяцию.
        public void AddIndivid(Individ ind)
        {
            Individ[] inds = new Individ[mInds.Length + 1];
            for (int i = 0; i < mInds.Length; i++)
                inds[i] = mInds[i];
            inds[mInds.Length] = ind;
            mInds = inds;
        }

        // Отбор.
        public void Selection()
        {
            Sort();
            Individ[] inds = new Individ[N];
            for (int i = 0; i < N; i++)
                inds[i] = mInds[i];
            mInds = inds;
        }

        // Сортировка.
        public void Sort()
        {
            Individ ind;
            for (int i = 1; i < mInds.Length; i++)
                for (int j = 0; j < mInds.Length - i; j++)
                    if (mInds[j].GetF() < mInds[j + 1].GetF())
                    {
                        ind = mInds[j];
                        mInds[j] = mInds[j + 1];
                        mInds[j + 1] = ind;
                    }
        }

        // Скрещивание и Мутация.
        public void CrossingAndMutation()
        {
            int n = Convert.ToInt32(Convert.ToDouble(N) * Wcross);
            int[,] indexes = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                indexes[i, 0] = -1;
                indexes[i, 1] = -1;
            }
            bool cond;
            for (int i = 0; i < n; i++)     // Выбираем n пар для скрещивания.
            {
                cond = false;
                while (!cond)
                {
                    indexes[i, 0] = Rand.rnd.Next(0, N);
                    indexes[i, 1] = Rand.rnd.Next(0, N);
                    cond = true;
                    for (int j = 0; j < i; j++)
                        if ((indexes[i, 0] == indexes[j, 0]) || (indexes[i, 1] == indexes[j, 1]) || (indexes[i,0] == indexes[i,1]))
                            cond = false;
                }
            }

            int div;
            Khromo[] kh_s1 = new Khromo[2];
            Khromo[] kh_s2 = new Khromo[2];
            Khromo kh_a1;
            Khromo kh_a2;
            for (int i = 0; i < n; i++)
            {
                div = Rand.rnd.Next(0, Individ.GetK() - 1);
                kh_s1 = mInds[indexes[i, 0]].GetKhromo().Split(div);
                kh_s2 = mInds[indexes[i, 1]].GetKhromo().Split(div);
                kh_a1 = Khromo.Assemble(kh_s1[0], kh_s2[1]);
                kh_a2 = Khromo.Assemble(kh_s2[0], kh_s1[1]);
                Individ ind1 = new Individ(kh_a1);
                Individ ind2 = new Individ(kh_a2);
                for (int j = 0; j < Individ.GetN(); j++)        // Мутация новый особей.
                    for (int k = 0; k < Individ.GetK(); k++)
                    {
                        int pos1 = Rand.rnd.Next(0, 101);
                        if (pos1 <= 0)                          // Каждый бит в хромосоме меняется с вер-ю 10%.
                            if (ind1[j, k] == 0)
                                ind1[j, k] = 1;
                            else
                                ind1[j, k] = 0;
                        int pos2 = Rand.rnd.Next(0, 101);
                        if (pos2 <= 0)                          // Каждый бит в хромосоме меняется с вер-ю 10%.
                            if (ind2[j, k] == 0)
                                ind2[j, k] = 1;
                            else
                                ind2[j, k] = 0;
                    }
                ind1.CalculateSQRT();
                ind2.CalculateSQRT();
                ind1.CalculateF();
                ind2.CalculateF();
                AddIndivid(ind1);
                AddIndivid(ind2);
            }

            int nMut = Convert.ToInt32(Convert.ToDouble(N) * Wmut);
            int[] indexesMut = new int[nMut];
            for (int i = 0; i < nMut; i++)
                indexesMut[i] = -1;
            for (int i = 0; i< nMut; i++)     // Выбираем n особей для мутации.
            {
                cond = false;
                while (!cond)
                {
                    indexesMut[i] = Rand.rnd.Next(0, N);
                    cond = true;
                    for (int j = 0; j < n; j++)
                        if ((indexesMut[i] == indexes[j, 0]) || (indexesMut[i] == indexes[j, 1]))
                            cond = false;
                    for (int j=0; j<i; j++)
                        if (indexesMut[i] == indexesMut[j])
                            cond = false;
                }
            }

            Individ ind_mut;
            for (int i=0; i<nMut; i++)
            {
                ind_mut = mInds[indexesMut[i]];
                for (int j=0; j<Individ.GetN(); j++)
                    for (int k=0; k<Individ.GetK(); k++)
                    {
                        int pos = Rand.rnd.Next(0,Convert.ToInt32(1.0/Wmut));
                        if (pos == Convert.ToInt32(0.5/Wmut))                   // Каждый бит в хромосоме меняется с вер-ю Wmut.
                            if (ind_mut[j, k] == 0)
                                ind_mut[j, k] = 1;
                            else
                                ind_mut[j, k] = 0;
                    }
                ind_mut.CalculateSQRT();
                ind_mut.CalculateF();
                AddIndivid(ind_mut);
            }

            Selection();
            Tcur++;
        }
        
    }


    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
