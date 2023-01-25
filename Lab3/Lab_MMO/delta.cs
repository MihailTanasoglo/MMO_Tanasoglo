using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_MMO
{
    public static class delta
    {
        public static void NegativeF_Free_Coefficients(double[,] matrix, List<int> basis)
        {

        }


        public static int Find_Leading_Column(double[,] simplex_table, bool uslovie)
        {
            int leading_Column = -1;
            double max_value = double.MinValue;
            double min_value = double.MaxValue;
            //поиск максимального по модулю числа в симплекс таблицы.

            for (int j = 1; j < simplex_table.GetLength(1); j++)
            {
                if (simplex_table[simplex_table.GetLength(0) - 1, j] < min_value && !uslovie)
                {
                    min_value = simplex_table[simplex_table.GetLength(0) - 1, j];
                    leading_Column = j;
                }

                if (simplex_table[simplex_table.GetLength(0) - 1, j] > max_value && uslovie && simplex_table[simplex_table.GetLength(0) - 1, j] > 0)
                {
                    max_value = simplex_table[simplex_table.GetLength(0) - 1, j];
                    leading_Column = j;
                }
            }
            return leading_Column;
        }

        //в качестве входного параметра выбирается ведущий столбец предоставляющий метод Find_Leading_Column()
        public static int Find_Leading_Row(double[,] simplex_table)
        {
            int leading_row = -1;
            double max_value = double.MinValue;

            for (int i = 0; i < simplex_table.GetLength(0) - 1; i++)
            {
                if (Math.Abs(simplex_table[i, 0]) > max_value)
                {
                    max_value = Math.Abs(simplex_table[i, 0]);
                    leading_row = i;
                }
            }
            return leading_row;
        }

        public static bool Search_Negative_Elements_Row(double[,] simplex_table, int leading_row)
        {
            for (int j = 1; j < simplex_table.GetLength(1); j++)
            {
                if (simplex_table[leading_row, j] < 0)
                    return true;
            }
            return false;
        }

        //поиск отрицательных элементов в свободных переменых 
        public static bool Search_negative_free_coefficient(double[,] simplex_table)
        {
            int row = simplex_table.GetLength(0);
            for (int i = 0; i < row - 1; i++)
            {
                if (simplex_table[i, 0] < 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static int Find_Leading_column(double[,] simplex_table, int leading_row)
        {
            double max_value = double.MinValue;
            int leading_Column = -1;
            for (int j = 1; j < simplex_table.GetLength(1); j++)
            {
                if (Math.Abs(simplex_table[leading_row, j]) > max_value && simplex_table[leading_row, j] != 1)
                {
                    max_value = Math.Abs(simplex_table[leading_row, j]);
                    leading_Column = j;
                }
            }
            return leading_Column;
        }

        public static Tuple<double[,], List<int>> Rectangle_Method(double[,] simplex_table, List<int> basis, int leading_row, int leading_Column)
        {

            basis[leading_row] = leading_Column;

            double[,] new_Simplex_table = new double[simplex_table.GetLength(0), simplex_table.GetLength(1)];

            for (int j = 0; j < simplex_table.GetLength(1); j++)
            {
                new_Simplex_table[leading_row, j] = simplex_table[leading_row, j] / simplex_table[leading_row, leading_Column];
            }


            for (int i = 0; i < simplex_table.GetLength(0); i++)
            {
                if (i == leading_row)
                    continue;
                for (int j = 0; j < simplex_table.GetLength(1); j++)
                {
                    new_Simplex_table[i, j] = simplex_table[i, j] - simplex_table[i, leading_Column] * new_Simplex_table[leading_row, j];
                }
            }
            Data_Output.Basis_Simplex_Table(new_Simplex_table);

            return Tuple.Create(new_Simplex_table, basis);
        }

        public static double[,] Delta(double[,] simplex_table, List<int> basis, double[] objective_function)
        {
            int row = simplex_table.GetLength(0);

            int col = simplex_table.GetLength(1);
            double[] delita = new double[simplex_table.GetLength(1)];

            for (int j = 0; j < col; j++)
            {
                for (int i = 0; i < row - 1; i++)
                {
                    delita[j] += objective_function[basis[i] - 1] * simplex_table[i, j];
                }
                delita[j] -= objective_function[j];
            }
            for (int j = 0; j < simplex_table.GetLength(1); j++)
            {
                simplex_table[row - 1, j] = delita[j];
            }

            return simplex_table;
        }

        public static bool Сhecking_plan_optimality(double[,] simplex_table, bool uslovie)
        {
            for (int j = 0; j < simplex_table.GetLength(1); j++)
            {
                if (simplex_table[simplex_table.GetLength(0) - 1, j] > 0 && uslovie)
                    return false;
                if (simplex_table[simplex_table.GetLength(0) - 1, j] < 0 && !uslovie)
                    return false;
            }
            return true;
        }

        public static int Find_Leading_column(double[,] simplex_table, bool uslovie, List<int> basis, List<int> invalid_variables)
        {

            int leading_Column = -1;
            double max_value = double.MinValue;
            double min_value = double.MaxValue;
            //поиск максимального  числа в симплекс таблицы.

            for (int j = 1; j < simplex_table.GetLength(1); j++)
            {
                if (simplex_table[simplex_table.GetLength(0) - 1, j] > max_value && uslovie && !invalid_variables.Contains(j) && simplex_table[simplex_table.GetLength(0) - 1, j] >= 0)
                {
                    max_value = simplex_table[simplex_table.GetLength(0) - 1, j];
                    leading_Column = j;
                }
                if (simplex_table[simplex_table.GetLength(0) - 1, j] < min_value && !uslovie && !invalid_variables.Contains(j) && simplex_table[simplex_table.GetLength(0) - 1, j] < 0)
                {
                    min_value = simplex_table[simplex_table.GetLength(0) - 1, j];
                    leading_Column = j;
                }
            }



            return leading_Column;
        }

        //в качестве входного параметра выбирается ведущий столбец предоставляющий метод Find_Leading_Column()
        public static int Find_Leading_Row(double[,] simplex_table, int leading_Column)
        {
            int leading_Row = -1;
            double min_value = double.MaxValue;
            for (int i = 0; i < simplex_table.GetLength(0) - 1; i++)
            {
                if ((simplex_table[i, 0] > 0) && (simplex_table[i, leading_Column] < 0)) continue;

                if ((simplex_table[i, 0] / simplex_table[i, leading_Column]) < min_value && simplex_table[i, leading_Column]!=0)
                {
                    min_value = simplex_table[i, 0] / simplex_table[i, leading_Column];
                    leading_Row = i;
                }
            }
            return leading_Row;
        }

        public static int Find_Leading_Row_2(double[,] simplex_table, int leading_Column,List<int> list_artificial_variables, List<int> basis)
        {
            int leading_Row = -1;
            double min_value = double.MaxValue;
            for (int i = 0; i < simplex_table.GetLength(0) - 1; i++)
            {
                if ((simplex_table[i, 0] > 0) && (simplex_table[i, leading_Column] < 0)) continue;

                if ((simplex_table[i, 0] / simplex_table[i, leading_Column]) < min_value && simplex_table[i, leading_Column] != 0 && list_artificial_variables.Contains(basis[i]-1))
                {
                    min_value = simplex_table[i, 0] / simplex_table[i, leading_Column];
                    leading_Row = i;
                }
            }
            return leading_Row;
        }

        public static bool Checking_Selectivity_Condition(int[,] selectivity_conditions, List<int> basis, int leading_column)
        {
            for (int i = 0; i < selectivity_conditions.GetLength(0); i++)
            {
                for (int j = 0; j < selectivity_conditions.GetLength(1); j++)
                {
                    if (selectivity_conditions[i, j] == leading_column)
                    {
                        if (j == 0)
                            if (basis.Contains(selectivity_conditions[i, j + 1] + 1))
                                return true;

                        if (j == 1)
                            if (basis.Contains(selectivity_conditions[i, j - 1] + 1))
                                return true;
                    }
                }
            }
            return false;
        }

        public static Tuple<double[,], List<int>, int[,]> Exclusion_Additional_Variables(double[,] simplex_table, List<int> basis, double[] objective_function, bool uslovie, int[,] selectivity_conditions,List<int> list_artificial_variables)
        {
            int row = simplex_table.GetLength(0);
            int col = simplex_table.GetLength(1);

            double[] result = new double[col];
            int leading_Column, leading_Row;


            int iteratia = 1;
            for(int m=0;m< list_artificial_variables.Count;m++)          
            {
                var invalid_variables = new List<int>();
                do
                {
                    leading_Column = Find_Leading_column(simplex_table, uslovie, basis, invalid_variables);
                    if (leading_Column == -1)
                    {
                        Console.WriteLine("Функция не ограничена. Оптимальное решение отсутствует");
                        break;
                    }
                    invalid_variables.Add(leading_Column);
                }
                while (Checking_Selectivity_Condition(selectivity_conditions, basis, leading_Column));

                if (leading_Column != -1)
                {
                    leading_Row = Find_Leading_Row_2(simplex_table, leading_Column, list_artificial_variables,basis);

                    if (leading_Row == -1)
                    {
                        Console.WriteLine("Функция не ограничена. Оптимальное решение отсутствует. Поскольку в разрешающем столбце {0} все значения отрицательные", leading_Column);
                        break;
                    }

                    int number_variables = basis.Count();
                    int[] a2 = new int[number_variables];
                    for (int i = 0; i < number_variables; i++)
                    {
                        if (i < number_variables - 2)
                            a2[i] = number_variables + 1 + i;
                        else a2[i] = number_variables + 1 + i + number_variables - 2;
                    }

                    if (leading_Column > number_variables - 2 && leading_Column <= number_variables)
                    {
                        bool l = basis.Contains(leading_Column + ((number_variables - 2) * 2) + 2);
                    }

                    basis[leading_Row] = leading_Column;

                    double[,] new_Simplex_table = new double[row, col];
                    for (int j = 0; j < col; j++)
                    {
                        new_Simplex_table[leading_Row, j] = simplex_table[leading_Row, j] / simplex_table[leading_Row, leading_Column];
                    }
                    for (int i = 0; i < row; i++)
                    {
                        if (i == leading_Row)
                            continue;
                        for (int j = 0; j < col; j++)
                            new_Simplex_table[i, j] = simplex_table[i, j] - simplex_table[i, leading_Column] * new_Simplex_table[leading_Row, j];
                    }
                    simplex_table = new_Simplex_table;

                    Data_Output.Calculation_Simplex_Table_2(simplex_table, iteratia, leading_Row, leading_Column);
                }

                iteratia++;
                int p = 0;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Базис");
                foreach (double a in basis)
                {
                    Console.Write("X[{0}] = {1}  ; ", p, a);
                    p++;
                }
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------------------");

                simplex_table = Delta(simplex_table, basis, objective_function);

                if (leading_Column == -1)
                    break;
            }

            return Tuple.Create(simplex_table, basis, selectivity_conditions);
        }

            public static Tuple<double[,], double[]> Calculate(double[,] simplex_table, List<int> basis, double[] objective_function, bool uslovie, int[,] selectivity_conditions)
        {
            int row = simplex_table.GetLength(0);
            int col = simplex_table.GetLength(1);

            double[] result = new double[col];
            int leading_Column, leading_Row;


            int iteratia = 1;
            while (!Сhecking_plan_optimality(simplex_table, uslovie))
            {
                var invalid_variables = new List<int>();
                do
                {
                    leading_Column = Find_Leading_column(simplex_table, uslovie, basis, invalid_variables);
                    if (leading_Column == -1)
                    {
                        Console.WriteLine("Функция не ограничена. Оптимальное решение отсутствует");
                        break;
                    }
                    invalid_variables.Add(leading_Column);
                }
                while (Checking_Selectivity_Condition(selectivity_conditions, basis, leading_Column));


                if (leading_Column != -1)
                {
                    leading_Row = Find_Leading_Row(simplex_table, leading_Column);

                    if (leading_Row == -1)
                    {
                        Console.WriteLine("Функция не ограничена. Оптимальное решение отсутствует. Поскольку в разрешающем столбце {0} все значения отрицательные", leading_Column);
                        break;
                    }

                    int number_variables = basis.Count();
                    int[] a2 = new int[number_variables];
                    for (int i = 0; i < number_variables; i++)
                    {
                        if (i < number_variables - 2)
                            a2[i] = number_variables + 1 + i;
                        else a2[i] = number_variables + 1 + i + number_variables - 2;
                    }

                    if (leading_Column > number_variables - 2 && leading_Column <= number_variables)
                    {
                        bool l = basis.Contains(leading_Column + ((number_variables - 2) * 2) + 2);
                    }

                    basis[leading_Row] = leading_Column;

                    double[,] new_Simplex_table = new double[row, col];
                    for (int j = 0; j < col; j++)
                    {
                        new_Simplex_table[leading_Row, j] = simplex_table[leading_Row, j] / simplex_table[leading_Row, leading_Column];
                    }
                    for (int i = 0; i < row; i++)
                    {
                        if (i == leading_Row)
                            continue;
                        for (int j = 0; j < col; j++)
                            new_Simplex_table[i, j] = simplex_table[i, j] - simplex_table[i, leading_Column] * new_Simplex_table[leading_Row, j];
                    }
                    simplex_table = new_Simplex_table;
                    Data_Output.Calculation_Simplex_Table(simplex_table, iteratia, leading_Row, leading_Column);
                }

                iteratia++;
                int p = 0;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Базис");
                foreach (double a in basis)
                {
                    Console.Write("X[{0}] = {1}  ; ", p, a);
                    p++;
                }
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------------------");

                simplex_table = Delta(simplex_table, basis, objective_function);

                if (leading_Column == -1)
                    break;
            }

            for (int i = 0; i < result.Length; i++)
            {
                int k = basis.IndexOf(i + 1);
                if (k != -1) result[i] = simplex_table[k, 0];
                else result[i] = 0;
            }

            return Tuple.Create(simplex_table, result);
        }
    }
}
