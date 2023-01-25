using System;
using System.Collections.Generic;

namespace Lab_MMO
{
    public class Linear_Programming
    {
        public int row { get; set; }
        public int col { get; set; }
        public double[,] canonical_form { get; set; }
        public int equality { get; set; } = 0;
        public List<int> basis { get; set; }
        public double[,] basic_simplex_table { get; set; }
        public double[] rezult { get; set; }
        public double Frezult { get; set; }

        public Linear_Programming(Tuple<double[,], string[], bool, bool> input_data)
        {
            if (!input_data.Item4)
            {
                var data = Сalculations.Canonical_Form(input_data.Item1, input_data.Item2, input_data.Item3);

                int u = 0;
                double[,] input_table = data.Item1;
                int row = input_table.GetLength(0);
                int col = input_table.GetLength(1);

                basis = new List<int>();

                for (int i = 0; i < row - 1; i++)
                {
                    basis.Add(0);
                }

                Data_Output.Reference_Plan(input_table);

                var tuple_basic_simplex_table = Сalculations.Basic_Simplex_Table(input_table, basis, data.Item2);
                basic_simplex_table = tuple_basic_simplex_table.Item1;
                basis = tuple_basic_simplex_table.Item2;
                Data_Output.Basic_Simplex_Table(basic_simplex_table);

                double[] objective_function = new double[basic_simplex_table.GetLength(1)];
                for (int i = 0; i < basic_simplex_table.GetLength(1); i++)
                {
                    objective_function[i] = basic_simplex_table[basic_simplex_table.GetLength(0) - 1, i] * -1;
                }

                if (input_data.Item3)
                {
                    var basis_choice = Сalculations.Basis_Choice(basic_simplex_table, basis, tuple_basic_simplex_table.Item3);
                    Data_Output.Basic_Simplex_Table(basis_choice.Item1);

                    var plan_optimality_basis = Сalculations.Сhecking_plan_optimality_basis(basis_choice.Item1, basis_choice.Item2, input_data.Item3);

                    var simplex_delta = Сalculations.Delta(plan_optimality_basis.Item1, plan_optimality_basis.Item2, objective_function);
                    Console.WriteLine();

                    var simplex_result = Сalculations.Calculate(simplex_delta, plan_optimality_basis.Item2, objective_function, input_data.Item3);

                    u = 0;
                    Console.WriteLine();
                    Console.WriteLine("Вывод значения базисов");
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    foreach (double a in simplex_result.Item2)
                    {
                        Console.Write("X[{0}] = {1}  ; ", u, a);
                        u++;
                    }
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    rezult = new double[simplex_result.Item2.GetLength(0)];
                    rezult = simplex_result.Item2;
                    Frezult = simplex_result.Item1[simplex_result.Item1.GetLength(0) - 1, 0];
                }
                else
                {
                    double[,] simplex_table = basic_simplex_table;
                    var simplex_result = Сalculations.Calculate(simplex_table, basis, objective_function, input_data.Item3);

                    u = 0;
                    Console.WriteLine();
                    Console.WriteLine("Вывод значения базисов");
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    foreach (double a in simplex_result.Item2)
                    {
                        Console.Write("X[{0}] = {1}  ; ", u, a);
                        u++;
                    }
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------------------------------------------");

                    rezult = new double[simplex_result.Item2.GetLength(0)];
                    rezult = simplex_result.Item2;
                    Frezult = simplex_result.Item1[simplex_result.Item1.GetLength(0) - 1, 0];
                }
            }
            else
            {
                int u = 0;
                int number_variables = Int32.Parse(input_data.Item2[0]);
                double[,] input_table = input_data.Item1;
                int row = input_table.GetLength(0);
                int col = input_table.GetLength(1);

                var basis_null = new List<int>();


                for (int i = 0; i < number_variables + 2; i++)
                {
                    basis_null.Add(0);
                }
                var basis = Initial_Basis(input_table, basis_null, number_variables);

                double[] objective_function = new double[input_table.GetLength(1)];
                for (int i = 0; i < input_table.GetLength(1); i++)
                {
                    objective_function[i] = input_table[input_table.GetLength(0) - 1, i] * 1;
                }

                var plan_optimality_basis = Сalculations.Сhecking_plan_optimality_basis(input_table, basis, input_data.Item3);
                Console.WriteLine();
                var simplex_delta = Сalculations.Delta(plan_optimality_basis.Item1, plan_optimality_basis.Item2, objective_function);
                Console.WriteLine();

                Data_Output.Basic_Simplex_Table(simplex_delta);
                var simplex_result = Сalculations.Calculate(simplex_delta, plan_optimality_basis.Item2, objective_function, input_data.Item3);

                u = 0;
                Console.WriteLine();
                Console.WriteLine("Вывод значения базисов");
                Console.WriteLine("--------------------------------------------------------------------------------");
                foreach (double a in simplex_result.Item2)
                {
                    Console.Write("X[{0}] = {1}  ; ", u, a);
                    u++;
                }
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------------------");
                rezult = new double[simplex_result.Item2.GetLength(0)];
                rezult = simplex_result.Item2;
                Frezult = simplex_result.Item1[simplex_result.Item1.GetLength(0) - 1, 0];
            }
        }
        public List<int> Initial_Basis(double[,] simplex_table, List<int> basis, int number_variables)
        {
            int count = 0;
            for (int i = 0; i < simplex_table.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < simplex_table.GetLength(1); j++)
                {
                    if (j > number_variables * 2 + 2 + count)
                    {
                        basis[i] = j;
                        break;
                    }
                }
                count++;
            }
            return basis;
        }

      
    }

}
