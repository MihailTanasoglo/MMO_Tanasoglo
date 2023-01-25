
using System;

namespace Lab_MMO
{

    public class Matrix_Game
    {

        public double number_variables_1 { get; set; }
        public double number_variables_2 { get; set; }
        public Matrix_Game(double[,] input_data)
        {
            bool flag = true;
            var strategy_set = MinMax_MaxMin(input_data);
            if (strategy_set.Item2)
            {
                Console.WriteLine("Чистая стратегия. Ответ {0} ", strategy_set.Item1);
                flag = false;
            };
            if (flag)
            {
                string[] compare_1 = new string[input_data.GetLength(0)];
                double[,] basic_simplex_table_1 = new double[input_data.GetLength(0) + 1, input_data.GetLength(1) + 1];
                number_variables_1 = input_data.GetLength(1);

                for (int i = 0; i < input_data.GetLength(0); i++)
                {
                    for (int j = 1; j < basic_simplex_table_1.GetLength(1); j++)
                    {
                        basic_simplex_table_1[i, j] = input_data[i, j - 1];
                    }
                }

                for (int j = 1; j < basic_simplex_table_1.GetLength(1); j++)
                {
                    basic_simplex_table_1[input_data.GetLength(0), j] = 1;
                }

                for (int i = 0; i < input_data.GetLength(0); i++)
                {
                    basic_simplex_table_1[i, 0] = 1;
                    compare_1[i] = "<=";
                }
                Data_Output.Basic_Simplex_Table(basic_simplex_table_1);
                var linear_programming_1 = new Linear_Programming(Tuple.Create(basic_simplex_table_1, compare_1, false, false));
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine(linear_programming_1.Frezult);


                string[] compare_2 = new string[input_data.GetLength(1)];
                double[,] basic_simplex_table_2 = new double[input_data.GetLength(1) + 1, input_data.GetLength(0) + 1];
                number_variables_2 = input_data.GetLength(0);

                for (int j = 0; j < basic_simplex_table_2.GetLength(0) - 1; j++)
                {
                    for (int i = 1; i < basic_simplex_table_2.GetLength(1); i++)
                    {
                        basic_simplex_table_2[j, i] = input_data[i - 1, j];
                    }
                }

                for (int j = 1; j < basic_simplex_table_2.GetLength(1); j++)
                {
                    basic_simplex_table_2[basic_simplex_table_2.GetLength(0) - 1, j] = 1;
                }

                for (int i = 0; i < basic_simplex_table_2.GetLength(0) - 1; i++)
                {
                    basic_simplex_table_2[i, 0] = 1;
                    compare_2[i] = ">=";
                }
                Data_Output.Basic_Simplex_Table(basic_simplex_table_2);
                var linear_programming_2 = new Linear_Programming(Tuple.Create(basic_simplex_table_2, compare_2, true, false));
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine(linear_programming_2.Frezult);

                Out_Rezult(linear_programming_1.Frezult, linear_programming_1.rezult, linear_programming_2.rezult);
            }
        }

        public void Out_Rezult(double Frezult, double[] rezult_1, double[] rezult_2)
        {
            double F = 1 / Frezult;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Вывод Результатов для первого игрока:");
            for (int i = 0; i < number_variables_1; i++)
            {
                rezult_1[i] = rezult_1[i] * F;
                Console.Write("X[{0}]= {1}  ", i + 1, rezult_1[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Вывод Результатов для второго игрока:");
            for (int i = 0; i < number_variables_2; i++)
            {
                rezult_2[i] = rezult_2[i] * F;
                Console.Write("X[{0}]= {1}  ", i + 1, rezult_2[i]);
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");
        }


        public Tuple<double, bool> MinMax_MaxMin(double[,] table)
        {
            double maxmin = 0;
            double minmax = double.MaxValue;

            for (int i = 0; i < table.GetLength(0); i++)
            {
                double min_value = double.MaxValue;
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j] < min_value) min_value = table[i, j];
                }
                if (min_value > maxmin) maxmin = min_value;

            }
            for (int j = 0; j < table.GetLength(1); j++)
            {
                double max_value = double.MinValue;
                for (int i = 0; i < table.GetLength(0); i++)
                {
                    if (table[i, j] > max_value) max_value = table[i, j];
                }
                if (max_value < minmax) minmax = max_value;

            }
            if (maxmin == minmax) return Tuple.Create(maxmin, true);
            else return Tuple.Create(maxmin, false);
        }
    }
}