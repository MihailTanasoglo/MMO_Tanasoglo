using System;
using System.Collections.Generic;

namespace Lab_MMO
{
    public static class Сalculations
    {
        public static Tuple<double[,], List<int>> Canonical_Form(double[,] table, string[] compare, bool uslovie)
        {
            int row = table.GetLength(0);
            int col = table.GetLength(1);
            int count = 0;
            List<int> equality = new List<int>();

            //  int equality = 0;
            for (int i = 0; i < row; i++)
            {
                if (i < compare.GetLength(0))
                {
                    if (compare[i] == ">=")
                    {
                        for (int j = 0; j < col; j++)
                        {
                            table[i, j] = table[i, j] * -1;
                        }
                    }
                    if (compare[i] == "=") equality.Add(i);
                }
                if ((i == compare.GetLength(0) || i == row - 1))
                {
                    for (int j = 0; j < col; j++)
                    {
                        table[i, j] = table[i, j] * -1;
                    }
                }

            }
            return Tuple.Create(table, equality);
        }
        public static Tuple<double[,], List<int>> Basis_Choice(double[,] table, List<int> basis, List<int> row_index)
        {
            int row = table.GetLength(0);
            int col = table.GetLength(1);
            double sum = 0;

            var nuli = new List<int>();

            for (int i = 0; i < row - 1; i++)
            {
                if (Find_Zero_Basis(basis) + nuli.Count < row - 1 && !row_index.Contains(i))
                {
                    nuli.Add(i);
                }
            }

            for (int k = 0; k < nuli.Count; k++)
            {
                int leading_Column = -1;

                for (int j = 1; j < col - Find_Zero_Basis(basis); j++)
                {
                    if (table[nuli[k], j] != 0)
                    {
                        leading_Column = j;
                        break;
                    }
                }

                basis[nuli[k]] = leading_Column;


                double[,] new_table = new double[row, col];
                for (int j = 0; j < col; j++)
                {
                    new_table[nuli[k], j] = table[nuli[k], j] / table[nuli[k], leading_Column];
                }


                for (int i = 0; i < row; i++)
                {
                    if (i == nuli[k])
                        continue;

                    for (int j = 0; j < col; j++)
                    {
                        if (i < row - 1)
                        {
                            new_table[i, j] = table[i, j] - table[i, leading_Column] * new_table[nuli[k], j];
                        }
                        else
                        {
                            new_table[i, j] = table[i, j];
                        }
                    }
                }
                table = new_table;
                Data_Output.Basic_Simplex_Table(new_table);
            }
            return Tuple.Create(table, basis);
        }

        public static Tuple<double[,], List<int>, List<int>> Basic_Simplex_Table(double[,] input_table, List<int> basis, List<int> equality)
        {
            int row = input_table.GetLength(0);
            int col = input_table.GetLength(1);

            double[,] basic_simplex_table = new double[row, col + row - 1 - equality.Count]; // размер симплект таблицы 

            int col_simpex_table = basic_simplex_table.GetLength(1);// количество столбцов в симплекс таблице
                                                                    // row_simpex_table = basic_simplex_table.GetLength(0); количество строк в симплектс таблице
            List<int> index_ravenstva = new List<int>();
            //заполнение симплекс таблицы
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col_simpex_table; j++)
                {

                    if (j < col)
                        basic_simplex_table[i, j] = input_table[i, j]; //переносим данные из входной таблицы в симплекс
                    else
                        basic_simplex_table[i, j] = 0; //все остальные элементы то есть коэфициенты дополнительных переменых приравнимаем к нулю

                }
            }
            List<int> row_index = new List<int>();
            int index2 = 0;
            for (int j = col; j < basic_simplex_table.GetLength(1); j++)
            {
                bool flag = false;
                for (int i = 0; i < row - 1; i++)
                {
                    if (equality.Count > 0)
                    {
                        foreach (int index in equality)
                        {
                            if (!equality.Contains(i))
                            {
                                basic_simplex_table[i, j] = 1;
                                flag = true;
                                equality.Add(i);
                                //   basis.Add(j);
                                basis[i] = j;
                                row_index.Add(i);
                                break;
                            }
                        }
                        if (flag) break;
                    }
                    else if (!equality.Contains(i))
                    {
                        basic_simplex_table[i, j] = 1;
                        // basis.Add(j);
                        basis[i] = j;
                        equality.Add(i);
                        break;
                    }
                }

            }
            return Tuple.Create(basic_simplex_table, basis, row_index);
        }

        public static bool Сhecking_plan_optimality(double[,] simplex_table, bool uslovie)
        {

            bool flag = true;
            //проходим по последней строке симплекс таблице в случи если имеются отрицательные элементы то план не оптимален и продолжаем итерации
            for (int j = 1; j < simplex_table.GetLength(1); j++)
            {
                if (simplex_table[simplex_table.GetLength(0) - 1, j] < 0 && !uslovie)
                {
                    flag = false;
                    break;
                }
                if (simplex_table[simplex_table.GetLength(0) - 1, j] > 0 && uslovie)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        //поиск отрицательных элементов в свободных переменых 
        public static bool Search_negative_element(double[,] simplex_table)
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
        public static Tuple<double[,], List<int>> Сhecking_plan_optimality_basis(double[,] simplex_table, List<int> basis, bool tip)
        {

            if (tip)
            {
                while (Search_negative_element(simplex_table))
                {
                    // List<int> inappropriate_basis = new List<int>();

                    double max_value = double.MinValue;
                    int leading_Column = -1;
                    int leading_row = -1;

                    for (int i = 0; i < simplex_table.GetLength(0) - 1; i++)
                    {
                        if (Math.Abs(simplex_table[i, 0]) > max_value && simplex_table[i, 0] < 0)
                        {
                            max_value = Math.Abs(simplex_table[i, 0]);
                            leading_row = i;
                        }
                    }

                    max_value = double.MinValue;
                    for (int j = 1; j < simplex_table.GetLength(1); j++)
                    {
                        if (Math.Abs(simplex_table[leading_row, j]) > max_value && simplex_table[leading_row, j] != 1)
                        {
                            max_value = Math.Abs(simplex_table[leading_row, j]);
                            leading_Column = j;
                        }
                    }

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

                    //for (int j = 0; j < simplex_table.GetLength(1); j++)
                    //{
                    //    new_Simplex_table[simplex_table.GetLength(0) - 1, j] = simplex_table[simplex_table.GetLength(0) - 1, j];
                    //}
                    simplex_table = new_Simplex_table;
                    Data_Output.Basis_Simplex_Table(simplex_table);
                }
            }
            return Tuple.Create(simplex_table, basis);
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
        public static int Find_Leading_Row(double[,] simplex_table, int leading_Column)
        {
            int leading_Row = 0;
            double min_value = double.MaxValue;
            for (int i = 0; i < simplex_table.GetLength(0) - 1; i++)
            {
                if ((simplex_table[i, 0] > 0) && (simplex_table[i, leading_Column] < 0)) continue;
                if ((simplex_table[i, 0] / simplex_table[i, leading_Column]) < min_value && (simplex_table[i, 0] / simplex_table[i, leading_Column]) != 0)
                {
                    min_value = simplex_table[i, 0] / simplex_table[i, leading_Column];
                    leading_Row = i;
                }
            }
            return leading_Row;
        }

        public static Tuple<double[,], double[]> Calculate(double[,] simplex_table, List<int> basis, double[] objective_function, bool uslovie)
        {
            int row = simplex_table.GetLength(0);
            int col = simplex_table.GetLength(1);

            double[] result = new double[col];
            int leading_Column, leading_Row;

            int iteratia = 1;
            while (!Сhecking_plan_optimality(simplex_table, uslovie))
            {
                leading_Column = Find_Leading_Column(simplex_table, uslovie);
                leading_Row = Find_Leading_Row(simplex_table, leading_Column);

                double[,] new_Simplex_table = new double[row, col];

                basis[leading_Row] = leading_Column;

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

                iteratia++;
                int p = 0;
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
            }

            for (int i = 0; i < result.Length; i++)
            {
                int k = basis.IndexOf(i + 1);
                if (k != -1) result[i] = simplex_table[k, 0];
                else result[i] = 0;
            }

            return Tuple.Create(simplex_table, result);
        }

        public static int Find_Zero_Basis(List<int> basis)
        {
            int zero_basis = 0;
            foreach (int element in basis)
            {
                if (element == 0) zero_basis++;

            }
            return zero_basis;
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
                    delita[j] += objective_function[basis[i]] * simplex_table[i, j];
                }
                delita[j] -= objective_function[j];
            }
            for (int j = 0; j < simplex_table.GetLength(1); j++)
            {
                simplex_table[row - 1, j] = delita[j];
            }

            return simplex_table;
        }
    }

}

