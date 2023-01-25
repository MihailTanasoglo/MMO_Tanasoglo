using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lab_MMO
{
    public class Transportation_Problem
    {
        public int row { get; set; }
        public int col { get; set; }
        public double[,] canonical_form { get; set; }
        public int equality { get; set; } = 0;

        int col_simplex_table, row_simplex_table;

        public List<int> basis { get; set; }
        public double[,] basic_simplex_table { get; set; }

        public Transportation_Problem(Tuple<double[,], bool> input_data)
        {
            basis = new List<int>();

            double[,] input_table = input_data.Item1;

            row = input_table.GetLength(0); //количество ограничений + целевая функция 
            col = input_table.GetLength(1);// свободные члены +  свободные неизвестные

            string[] compare = new string[row + col-2];

            double row_sum = 0, col_sum = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (i == 0)
                        row_sum = input_table[i, j] + row_sum;
                    if (j == 0)
                        col_sum = input_table[i, j] + col_sum;
                }
            }

            if(row_sum<col_sum)
            {
                for(int i=0;i<row+col-2; i++)
                {
                    if(i<row-1)
                    compare[i] = "<=";
                    else compare[i] = "=";
                }
            }
            else if(row_sum > col_sum)
            {
                for (int i = 0; i < row + col-2; i++)
                {
                    if (i > row)
                        compare[i] = "<=";
                    else compare[i] = "=";
                }
            }

            double[,] transper_input_table = new double[col, row];

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    transper_input_table[i, j] = input_table[j, i];
                }
            }


            basic_simplex_table = new double[row + col - 1, (row - 1) * (col - 1) + 1];
            row_simplex_table = basic_simplex_table.GetLength(0);
            col_simplex_table = basic_simplex_table.GetLength(1);

           
            for (int i = 1; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (j == 0)
                    {
                        basic_simplex_table[i - 1, 0] = input_table[i, j];
                    }
                    else
                        //    if (i == 1) basic_simplex_table[i - 1, j] = input_table[i, j];
                        basic_simplex_table[i - 1, j + (col - 1) * (i - 1)] = 1;//input_table[i, j];
                    if (j != 0 && i != 0)
                    {
                        basic_simplex_table[row + col - 2, j + ((col - 1) * (i - 1))] = input_table[i, j];
                    }
                }
            }

            for (int i = 1; i < col; i++)
            {

                for (int j = 0; j < row; j++)
                {

                    if (j == 1 && i == 1)
                    {
                        basic_simplex_table[i + row - 2, j] = 1;//transper_input_table[i, j];
                        continue;
                    };
                    if (j == 0)
                    {
                        basic_simplex_table[i + row - 2, 0] = transper_input_table[i, j];
                    }
                    else
                        basic_simplex_table[i + row - 2, (((j - 1) * (col - 1) + 1 * i))] = 1;// transper_input_table[i, j];

                }
            }
            
            var linear_programming = new Linear_Programming(Tuple.Create(basic_simplex_table, compare, input_data.Item2,false));
            double[] rezult2 = new double[linear_programming.rezult.GetLength(0)];
            rezult2 = linear_programming.rezult;

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------");

            double[,] a = new double[row - 1, col - 1];
            for (int i = 0; i < a.Length; i++)
            {
                a[i / a.GetLength(1), i % a.GetLength(1)] = rezult2[i];
            }

            for (int i = 1; i < row ; i++)
            {
               
                for (int j = 1; j < col ; j++)
                {
                    input_table[i, j] = a[i - 1, j - 1];
                }
            }

            for (int i = 0; i < row ; i++)
            {
                  Console.WriteLine();
                for (int j = 0; j < col ; j++)
                {
                    if (input_table[i, j] != 0)
                        Console.Write("{0,8}  |", input_table[i, j].ToString("0.0", CultureInfo.InvariantCulture));
                    else Console.Write("{0,8}  |", input_table[i, j]);
                }
            }

        }
    }
}
