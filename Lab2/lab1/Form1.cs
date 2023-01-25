using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

/*дописать функцию поиска циклов
 * 
 * 
 */

namespace MMO
{
    public partial class Form1 : Form
    {
        TransportProblem TP = null;
        float[,] SupportPlan = null;
        float[,] Optimum;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void gridA_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            gridC.RowCount++;
        }

        private void gridA_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (gridC.RowCount > 0) gridC.RowCount--;
        }

        private void CreateColumnsHeaders(DataGridView grid)
        {
            grid.Columns.Clear();
            DataGridViewColumn[] newColumns = new DataGridViewColumn[gridB.Rows.Count - 1];
            for (int i = 0; i < newColumns.Length; i++)
            {
                DataGridViewTextBoxColumn ColC = new System.Windows.Forms.DataGridViewTextBoxColumn();
                grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ColC });
                ColC.FillWeight = 50F;
                ColC.HeaderText = "B" + (grid.Columns.Count).ToString();
                ColC.Name = (grid.Columns.Count).ToString();
                ColC.Width = 50;
            }
        }

        private void gridB_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        { 
            CreateColumnsHeaders(gridC);
        }

        private void gridB_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            gridC.Columns.Remove((e.RowIndex + 1).ToString());
            int i = 1;
            foreach(DataGridViewTextBoxColumn Col in gridC.Columns)
            {
                Col.Name = i.ToString();
                Col.HeaderText = Col.Name;
                i++;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            gridA.RowCount = 1;
            gridB.RowCount = 1;
            gridC.ColumnCount = 1;
            gridC.RowCount = 1;
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\Users\\User\\Desktop\\Примеры";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        StreamReader SR = new StreamReader(myStream);
                        String[] Sizes = SR.ReadLine().Split(' ');
                        int Asize = 0, Bsize = 0;
                        int.TryParse(Sizes[0], out Asize);
                        int.TryParse(Sizes[1], out Bsize);
                        String A = SR.ReadLine();
                        String B = SR.ReadLine();
                        String[] C = new String[Asize];
                        for (int i = 0; i < Asize; i++) C[i] = SR.ReadLine();
                        try
                        {
                            TP = new TransportProblem(Asize, Bsize, A, B, C);
                        }
                        catch(Exception exc)
                        { MessageBox.Show(exc.Message); }
                    }
                    myStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }       
        }

        private void FillBigGrid(DataGridView grid, float[,] arr)
        {
            DataGridViewRow DataGridRow = new DataGridViewRow();
            for (int k = 0; k < TP.ASize; k++)
            {
                DataGridRow = new DataGridViewRow();
                DataGridRow.CreateCells(grid);
                for (int j = 0; j < TP.BSize; j++) DataGridRow.Cells[j].Value = arr[k, j].ToString();
                DataGridRow.HeaderCell.Value = "A" + (k + 1).ToString();
                grid.Rows.Insert(grid.Rows.Count - 1, DataGridRow);
            }
        }

        private void FillGrids()
        {
            for (int i = 0; i < TP.ASize; i++) gridA.Rows.Add(TP.mA[i].ToString());
            for (int i = 0; i < TP.BSize; i++) gridB.Rows.Add(TP.mB[i].ToString());
            FillBigGrid(gridC, TP.mC);            
       }

        private void btnFillGrids_Click(object sender, EventArgs e)
        {
            gridA.Visible = true;
            gridB.Visible = true;
            gridC.Visible = true;
            FillGrids();
        }

        private void btnNordWest_Click(object sender, EventArgs e)
        {
            CreateColumnsHeaders(gridSupport);
            SupportPlan = TP.NordWest();
            FillBigGrid(gridSupport, SupportPlan);
        }

        private void btnMinEl_Click(object sender, EventArgs e)
        {
            CreateColumnsHeaders(gridSupport);
            SupportPlan = TP.MinEl();
            FillBigGrid(gridSupport, SupportPlan);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            int N = 0;
            for (int i = 0; i < SupportPlan.Length; i++)
            {
                int j = (i - i % TP.BSize) / TP.BSize;
                int k = i % TP.BSize;
                if (SupportPlan[j, k] == SupportPlan[j, k]) N++;
            }
            lblCheck1.Text = "N = " + TP.ASize.ToString() + " + " + TP.BSize.ToString() + " - 1";
            if (N == TP.ASize + TP.BSize - 1)
            {
                lblCheck1.Text += " = " + N.ToString();
                lblCheck2.Text = "==> ОК";
            }
            else
            {
                lblCheck1.Text = " <> " + N.ToString();
                lblCheck2.Text = "==> не ОК";
            }
        }

        private void btnFirstPay_Click(object sender, EventArgs e)
        {
            float Sum = 0;
            for (int i = 0; i < SupportPlan.Length; i++)
            {
                int j = (i - i % TP.BSize) / TP.BSize;
                int k = i % TP.BSize;
                if (SupportPlan[j, k] == SupportPlan[j, k])
                    Sum += SupportPlan[j, k] * TP.mC[j, k];
            }
            lblFirstPay.Text = Sum.ToString();
        }

        private void btnMakeGood_Click(object sender, EventArgs e)
        {
            btnOpen_Click(null, null);
            btnFillGrids_Click(null, null);
            //btnMinEl_Click(null, null);
            btnNordWest_Click(null, null);
            
        }
                
        private void button1_Click_1(object sender, EventArgs e)
        {
            CreateColumnsHeaders(gridFinal);
            Optimum = TP.PotenMeth(SupportPlan);
            FillBigGrid(gridFinal, Optimum);
        }

        private void btnStep2_Click(object sender, EventArgs e)
        {
            float Sum = 0;
            for (int i = 0; i < Optimum.Length; i++)
            {
                int j = (i - i % TP.BSize) / TP.BSize;
                int k = i % TP.BSize;
                if (Optimum[j, k] == Optimum[j, k])
                    Sum += Optimum[j, k] * TP.mC[j, k];
            }
            lblOptimum.Text = Sum.ToString();
        }

        private void btnFogel_Click(object sender, EventArgs e)
        {

        }
    }

    public class TransportProblem
    {
        class InvalidInpFormat : ApplicationException
        {
            public InvalidInpFormat() : base() { }
            public InvalidInpFormat(string str) : base(str) { }
            public override string ToString()
            {
                return Message;
            }
        }
        // склады
        public float[] mA;
        // потребители
        public float[] mB;
        // Издержки
        public float[,] mC;
        public int ASize;
        public int BSize;
        // Тут будем хранить цикл
        private Point[] cycle;

        // Конструкторы
        public TransportProblem(float[] nA, float[] nB, float[,] nC)
        {
            if ((nA.Length != nC.GetLength(0))||(nB.Length != nC.GetLength(1)))
                throw new InvalidInpFormat("Размеры массива затрат не соответствуют размерам массивов поставщиков и складов");
            this.mA = nA; this.mB = nB; this.mC = nC;
            this.ASize = nA.Length; this.BSize = nB.Length;
        }
        public TransportProblem(int _Asize, int _Bsize, string sA, string sB, string[] sC)
        {
            ASize = _Asize; BSize = _Bsize;
            float x = 0;
            string[] StrArr = sA.Split(' ');
            if(StrArr.Length != ASize) 
                throw new InvalidInpFormat("Размеры массива А не соответствуют заявленным");
            mA = new float[ASize];
            for (int i = 0; i < mA.Length; i++) if (float.TryParse(StrArr[i], out x)) mA[i] = x;

            StrArr = sB.Split(' ');
            if (StrArr.Length != BSize)
                throw new InvalidInpFormat("Размеры массива B не соответствуют заявленным");            
            mB = new float[BSize];
            for (int i = 0; i < mB.Length; i++) if (float.TryParse(StrArr[i], out x)) mB[i] = x;

            float sumA = 0;
            Array.ForEach(mA, delegate (float f) { sumA += f; });
            float sumB = 0;
            Array.ForEach(mB, delegate(float f) { sumB += f; });
            float dif = sumA - sumB;
            if (dif > 0)
            {
                float[] bufArr = mB;
                mB = new float[bufArr.Length + 1];
                bufArr.CopyTo(mB, 0);
                mB[mB.Length - 1] = Math.Abs(dif);
                BSize++;
            }
            else if (dif < 0)
            {
                float[] bufArr = mA;
                mA = new float[bufArr.Length + 1];
                bufArr.CopyTo(mA, 0);
                mA[mA.Length - 1] = Math.Abs(dif);
                ASize++;
            }

            mC = new float[ASize,BSize];            
            for (int j = 0; j < sC.Length; j++)
            {  
                StrArr = sC[j].Split(' ');                
                if (StrArr.Length != _Bsize)
                    throw new InvalidInpFormat("Длина одной из строк входного файла не соответствует длине массива В");  
                for (int i = 0; i < _Bsize; i++) if (float.TryParse(StrArr[i], out x)) mC[j,i] = x;
            }
        }
        // Строим опорные планы тут
        bool isEmpty(float[] arr)
        {
            return Array.TrueForAll(arr, delegate(float x) { return x == 0; });
        }

        private void NanToEmpty(float[,] outArr)
        {
            for (int i = 0; i < ASize; i++)
                for (int j = 0; j < BSize; j++)
                    if (outArr[i, j] == 0) outArr[i, j] = float.NaN;
        }

        float findMin(float[,] Arr, bool[,] pr, out int indi, out int indj)
        {
            indi = -1; indj = -1;
            float min = float.MaxValue;
            for (int i = 0; i < ASize; i++)
                for (int j = 0; j < BSize; j++)
                    if ((pr[i, j]) && (Arr[i, j] < min))
                    {
                        min = Arr[i, j];
                        indi = i; indj = j;
                    }
            return min;                        
        }
        //
        public float[,] VolgelsMethod()
        {
            return null;
        }

        // Метод северо-западного угла
        public float[,] NordWest()
        {
            float[] Ahelp = mA;
            float[] Bhelp = mB;
            int i = 0, j = 0;
            float[,] outArr = new float[ASize,BSize];
            NanToEmpty(outArr); 

            while (!(isEmpty(Ahelp) && isEmpty(Bhelp)))
            {
                float Dif = Math.Min(Ahelp[i],Bhelp[j]);
                outArr[i, j] = Dif;
                Ahelp[i] -= Dif; Bhelp[j] -= Dif;
                if ((Ahelp[i] == 0) && (Bhelp[j] == 0) && (j + 1 < BSize)) outArr[i, j + 1] = 0;
                if (Ahelp[i] == 0) i++;
                if (Bhelp[j] == 0) j++;                                
            }                       
            return outArr;
        }

        class FindWay
        {
            FindWay Father;
            Point Root;
            FindWay[] Childrens;
            Point[] mAllowed;
            Point Begining;
            //true - вниз/вверх
            //false - влево/вправо
            bool flag;
            public FindWay(int x, int y, bool _flag, Point[] _mAllowed, Point _Beg, FindWay _Father)
            {
                Begining = _Beg;
                flag = _flag;
                Root = new Point(x, y);
                mAllowed = _mAllowed;
                Father = _Father;
            }
            public Boolean BuildTree()
            {
                Point[] ps = new Point[mAllowed.Length];
                int Count = 0;
                for (int i = 0; i < mAllowed.Length; i++)
                    if (flag)
                    {
                        if (Root.Y == mAllowed[i].Y)  
                        {
                            Count++;
                            ps[Count - 1] = mAllowed[i];
                        }

                    }
                    else
                        if (Root.X == mAllowed[i].X)
                        {
                            Count++;
                            ps[Count - 1] = mAllowed[i];
                        }

                FindWay fwu = this;
                Childrens = new FindWay[Count];
                //Point[] ss = new Point[mAllowed.Length];
                int k = 0;
                for (int i = 0; i < Count; i++)
                {
                    if (ps[i] == Root) continue;
                    if (ps[i] == Begining)
                    {
                        while (fwu != null)
                        {
                            mAllowed[k] = fwu.Root;
                            fwu = fwu.Father;
                            k++;
                        };
                        for (; k < mAllowed.Length; k++) mAllowed[k] = new Point(-1, -1);
                        return true;
                    }
                    
                    if(!Array.TrueForAll<Point>(ps,p => ((p.X == 0)&&(p.Y==0))))
                        {
                            Childrens[i] = new FindWay(ps[i].X, ps[i].Y, !flag, mAllowed, Begining, this);
                            Boolean result = Childrens[i].BuildTree();
                            if (result) return true;
                        }
                }
                return false;
            }

        }

        // Метод минимального элемента
        //public float[,] MinEl()
        public float[,] MinEl()
        {
            float[] Ahelp = this.mA;
            float[] Bhelp = this.mB;
            int i, j;
            float min;
            float[,] outArr = new float[this.ASize, this.BSize];
            bool[,] pArr = new bool[this.ASize, this.BSize];
            for (i = 0; i < this.ASize; i++)
            {
                for (j = 0; j < this.BSize; j++)
                {
                    pArr[i, j] = true;
                }
            }
            i = 0;
            j = 0;
            int k;
            int count = 0;
            while (!this.isEmpty(Ahelp) || !this.isEmpty(Bhelp))
            {
                min = this.findMin(this.mC, pArr, out i, out j);
                float Dif = Math.Min(Ahelp[i], Bhelp[j]);
                outArr[i, j] += Dif; count++;
                Ahelp[i] -= Dif;
                Bhelp[j] -= Dif;
                if (Ahelp[i] == 0f)
                {
                    k = 0;
                    while (k < this.BSize)
                    {
                        pArr[i, k] = false;
                        k++;
                    }
                }
                if (Bhelp[j] == 0f)
                {
                    for (k = 0; k < this.ASize; k++)
                    {
                        pArr[k, j] = false;
                    }
                }
            }            
            this.NanToEmpty(outArr);

            // Нуль-загрузка
            int difference = (ASize + BSize - 1) - count;
            for (int l = 0; l < difference; l++)
            {
                //выбираем непустые
                Allowed = new Point[count + 1];
                k = 0;
                for (i = 0; i < ASize; i++)
                    for (j = 0; j < BSize; j++)
                        if (outArr[i, j] == outArr[i, j])
                        {
                            Allowed[k] = new Point(i, j);
                            k++;
                        }
                // ищем куда загрузить
                Boolean p = true;
                Point Nl = new Point(0, 0);
                //Исправить ошибку выхода за пределы
                int tn = 0;

                for (i = 0; (i < ASize) && p; i++)
                    for (j = 0; (j < BSize) && p; j++)
                    {
                        Nl = Allowed[tn++] = new Point(i, j);
                        FindWay fw = new FindWay(i, j, true, Allowed, new Point(i, j), null);
                        p = fw.BuildTree();
                    }
                if (!p) outArr[Nl.X, Nl.Y] = 0;
            }

            return outArr;
        } 

        // Оптимизация методом потенциалов
         // вспомогательные функции
          // функция заполняет вспомогательные массивы U и V
          // пока работает...
        private void FindUV(float[] U, float[] V, float[,] HelpMatr)
        {
            //для проверки вычислена ли Ui Vi использую массив boolean'ов
            //даже 2 массива. в одном признак того вычислена ли соответствующий потенциал
            //во втором прошлись ли мы по строке/строчке этого потенциала
            //алгоритм позволит за конечное число итераций вычислить все потенциалы. ура.
            bool[] U1 = new bool[ASize];
            bool[] U2 = new bool[ASize];
            bool[] V1 = new bool[BSize];
            bool[] V2 = new bool[BSize];
            //V[BSize - 1] = 0;
            //V1[BSize - 1] = true;
            // пока все элементы массивов V1 и U1 не будут равны true
            while (!(AllTrue(V1) && AllTrue(U1)))
            {
                int i = -1;
                int j = -1;
                for (int i1 = BSize - 1; i1 >= 0; i1--)
                    if (V1[i1] && !V2[i1]) i = i1;
                for (int j1 = ASize - 1; j1 >= 0; j1--)
                    if (U1[j1] && !U2[j1]) j = j1;

                if ((j == -1) && (i == -1))
                for (int i1 = BSize - 1; i1 >= 0; i1--)
                    if (!V1[i1] && !V2[i1])
                    {
                        i = i1;
                        V[i] = 0;
                        V1[i] = true;
                        break;
                    }
                if ((j == -1)&&(i == -1))
                for (int j1 = ASize - 1; j1 >= 0; j1--)
                    if (!U1[j1] && !U2[j1])
                    {
                        j = j1;
                        U[j] = 0;
                        U1[j] = true;
                        break;
                    }

                if (i != -1)
                {
                    for (int j1 = 0; j1 < ASize; j1++)
                    {
                        if (!U1[j1]) U[j1] = HelpMatr[j1, i] - V[i];
                        if (U[j1] == U[j1]) U1[j1] = true;
                    }
                    V2[i] = true;
                }

                if (j != -1)
                {
                    for (int i1 = 0; i1 < BSize; i1++)
                    {
                        if (!V1[i1]) V[i1] = HelpMatr[j, i1] - U[j];
                        if (V[i1] == V[i1]) V1[i1] = true;
                    }
                    U2[j] = true;
                }

            }
            int rt = 0;
        }

        private Boolean AllPositive(float[,] m)
        {
            Boolean p = true;
            for (int i = 0; (i < ASize) && p; i++)
                for (int j = 0; (j < BSize) && p; j++)
                    if (m[i, j] < 0) p = false;
            return p;
        }

        private bool AllTrue(bool[] arr)
        {
            return Array.TrueForAll(arr, delegate(bool x) { return x; });
        }

          // дозаполняет матрицу S оценками
        private float[,] MakeSMatr(float[,] M, float[] U, float[] V)
        {

            float[,] HM = new float[ASize, BSize];
            for (int i = 0; i < ASize; i++)
                for (int j = 0; j < BSize; j++)
                {
                    HM[i, j] = M[i, j];
                    if (HM[i, j] != HM[i, j]) 
                        HM[i, j] = mC[i, j] - (U[i] + V[j]);
                }
            return HM;
        }

        private Point[] Allowed;// хранит координаты клеток, в которых есть груз
        
        public int[] arra = new int[5];        

        private Point[] GetCycle(int x, int y)
        {
            Point Beg = new Point(x, y);
            FindWay fw = new FindWay(x, y, true, Allowed, Beg, null);
            fw.BuildTree();
            Point[] Way = Array.FindAll<Point>(Allowed, delegate(Point p) { return (p.X != -1) && (p.Y != -1); });
            return Way;
        }

        // находит плохой цикл и крутит его
        private void Roll(float[,] m, float[,] sm)
        {
            Point minInd = new Point();
            float min = float.MaxValue;
            int k = 0;
            Allowed = new Point[ASize+BSize];
            for (int i = 0; i < ASize; i++)
                for (int j = 0; j < BSize; j++)
                {
                    if (m[i, j] == m[i, j])
                    {
                        Allowed[k].X = i;
                        Allowed[k].Y = j; 
                        k++;
                    }                    
                    // заодно ищем макс по модулю отр элемент
                    if (sm[i, j] < min)
                    {
                        min = sm[i, j];
                        minInd.X = i;
                        minInd.Y = j;
                    }
                }
            // Ищем цикл
            Allowed[Allowed.Length - 1] = minInd;
            Point[] Cycle = GetCycle(minInd.X, minInd.Y);
            float[] Cycles = new float[Cycle.Length];
            Boolean[] bCycles = new Boolean[Cycle.Length];
            for (int i = 0; i < bCycles.Length; i++)
                bCycles[i] = i == bCycles.Length - 1 ? false : true;
            min = float.MaxValue;
            /* проблема в следующем:
             * цикл мы находим правильно
             * а вот посчитать правильно не можем
             * ниже поиск минимального элемента
             */
            // поиск минимального
            for (int i = 0; i < Cycle.Length; i++)
            {
                Cycles[i] = m[Cycle[i].X, Cycle[i].Y];
                if ((i % 2 == 0) && (Cycles[i] == Cycles[i]) && (Cycles[i] < min))
                {
                    min = Cycles[i];
                    minInd = Cycle[i];
                }
                if (Cycles[i] != Cycles[i]) Cycles[i] = 0;
            }
            int point1 = 0;
            // вычитание-прибавление
            for (int i = 0; i < Cycle.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Cycles[i] -= min;
                    m[Cycle[i].X, Cycle[i].Y] -= min;
                }
                else
                {   
                    Cycles[i] += min;
                    if (m[Cycle[i].X, Cycle[i].Y] != m[Cycle[i].X, Cycle[i].Y]) m[Cycle[i].X, Cycle[i].Y] = 0;
                    m[Cycle[i].X, Cycle[i].Y] += min;
                }           
            }
            m[minInd.X, minInd.Y] = float.NaN;
        }

        // сама оптимизация
        public float[,] PotenMeth(float[,] SupArr)
        {   
            // расчитываем Ui и Vi
             //подготовка
            int i = 0, j = 0;
            float[,] HelpMatr = new float[ASize, BSize];
            for (i = 0; i < ASize; i++)
                for (j = 0; j < BSize; j++)
                    if (SupArr[i, j] == SupArr[i, j]) HelpMatr[i, j] = mC[i, j];
                    else HelpMatr[i, j] = float.NaN;

            //расчёт
            float[] U = new float[ASize];
            float[] V = new float[BSize];        
            FindUV(U, V, HelpMatr);
            float[,] SMatr = MakeSMatr(HelpMatr, U, V);
            //пока все потенциалы не станут положительнымми, будем снова и снова считать
            while (!AllPositive(SMatr))
            {     
                Roll(SupArr, SMatr);
                for (i = 0; i < ASize; i++)
                    for (j = 0; j < BSize; j++)
                    {
                        if (SupArr[i, j] == float.PositiveInfinity)
                            {
                                HelpMatr[i, j] = mC[i,j];
                                SupArr[i, j] = 0;
                                continue;
                            }
                        if(SupArr[i, j] == SupArr[i, j]) HelpMatr[i, j] = mC[i, j];
                        else HelpMatr[i, j] = float.NaN;
                    }
                FindUV(U, V, HelpMatr);
                SMatr = MakeSMatr(HelpMatr, U, V);
            }

            return SupArr;
        }
        
    }
}
