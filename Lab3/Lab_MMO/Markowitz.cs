using System;
using System.Collections.Generic;

namespace Lab_MMO
{
    public class Markowitz_Portfolio
    {
        public Markowitz_Portfolio(Tuple<double[,], double[,], double[], bool> input_data)
        {            

            int row = input_data.Item1.GetLength(0);
            double[] function_equation = Objective_Function_Equation(input_data.Item1, input_data.Item3);
            var derivatives = Derivatives(input_data);

            Data_Output.Derivatives(derivatives);

            var solution_linear_problem = Add_Artificial_Variables(derivatives, input_data.Item1.GetLength(0), input_data.Item4);
            Data_Output.Derivatives(solution_linear_problem.Item1);


            var simplex_table = Simpex_Table(solution_linear_problem.Item1);
            Data_Output.Derivatives(simplex_table);

            var selectivity_conditions = Selectivity_Conditions(input_data.Item1.GetLength(0), input_data.Item2.GetLength(1));

            var basis = Basis_Variables(simplex_table);
            int leading_row = -1;

            double[] objective_function = new double[simplex_table.GetLength(1)];
            for (int i = 0; i < simplex_table.GetLength(1); i++)
            {
                if (i >= simplex_table.GetLength(1) - input_data.Item1.GetLength(0) && input_data.Item4)
                    objective_function[i] = 1;
                if (i >= simplex_table.GetLength(1) - input_data.Item1.GetLength(0) && !input_data.Item4)
                    objective_function[i] = -1;
            }


            while (delta.Search_negative_free_coefficient(simplex_table))
            {
                leading_row = delta.Find_Leading_Row(simplex_table);
                if (leading_row == -1)
                    break;
                else
                {
                    if (!delta.Search_Negative_Elements_Row(simplex_table, leading_row))
                    {
                        Console.Write("Задача не имеет решения. ");
                        Console.WriteLine("Поскольку max по модулю свободные коэфициент в строке {0} нет ортицательных коэфициентов.", leading_row);
                        break;
                    }

                    int leading_column = delta.Find_Leading_column(simplex_table, leading_row);

                    var simplex_delta = delta.Rectangle_Method(simplex_table, basis, leading_row, leading_column);
                    simplex_table = simplex_delta.Item1;
                    basis = simplex_delta.Item2;
                }
            }

            simplex_table = delta.Delta(simplex_table, basis, objective_function);
            Data_Output.Derivatives(simplex_table);

            var first_phase_simplex_method = delta.Exclusion_Additional_Variables(simplex_table, basis, objective_function, input_data.Item4, selectivity_conditions, solution_linear_problem.Item2);

            simplex_table = delta.Delta(simplex_table, basis, objective_function);

            var simplex_result = delta.Calculate(simplex_table, first_phase_simplex_method.Item2, objective_function, input_data.Item4, first_phase_simplex_method.Item3);


            int u = 0;
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
            var rezult = new double[simplex_result.Item2.GetLength(0)];
            rezult = simplex_result.Item2;
            var Frezult = simplex_result.Item1[simplex_result.Item1.GetLength(0) - 1, 0];



        }

        public int[,] Selectivity_Conditions(int number_variables, int number_restrictions)
        {
            int[,] selectivity_conditions = new int[ number_variables + number_restrictions, 2];

            for (int i = 0; i < selectivity_conditions.GetLength(0); i++)
            {
                if (i < number_variables)
                {
                    selectivity_conditions[i, 0] = i+1;
                    selectivity_conditions[i, 1] = i+ number_variables + number_restrictions+1;
                }
                else
                {
                    selectivity_conditions[i, 0] = i + 1;
                    selectivity_conditions[i, 1] = i + number_variables + number_restrictions + 1;
                }
            }
            return selectivity_conditions;
        }

        public double[] Objective_Function_Equation(double[,] covariance_matrix, double[] free_odds)
        {
            int dimension = covariance_matrix.GetLength(0) * (covariance_matrix.GetLength(0) - 1) / 2 + covariance_matrix.GetLength(0) + free_odds.GetLength(0);

            double[] function_equation = new double[dimension];
            for (int i = 0; i < free_odds.GetLength(0); i++)
            {
                function_equation[i] = free_odds[i];
            };
            int k = 0;
            int l = 0;
            for (int i = 0; i < covariance_matrix.GetLength(0); i++)
            {
                for (int j = 0; j < covariance_matrix.GetLength(1); j++)
                {
                    if (j >= l)
                    {
                        if (j != i)
                            function_equation[j + k + free_odds.GetLength(0)] = covariance_matrix[i, j] * 2;
                        else function_equation[j + k + free_odds.GetLength(0)] = covariance_matrix[i, j];
                    }

                }
                l++;
                k = k + covariance_matrix.GetLength(0) - l;
            }
            return function_equation;

        }
        public double[,] Derivatives(Tuple<double[,], double[,], double[], bool> input_data)
        {
            double[,] derivatives = new double[(input_data.Item1.GetLength(0) + input_data.Item2.GetLength(1)), (input_data.Item1.GetLength(0) * 2 + input_data.Item2.GetLength(1) * 2)];
            int count = 0;
            int count2 = input_data.Item2.GetLength(1);

            for (int i = 0; i < derivatives.GetLength(0); i++)
            {
                for (int j = 0; j < derivatives.GetLength(1); j++)
                {
                    if (i < input_data.Item1.GetLength(0) && j < input_data.Item1.GetLength(1))
                    {
                        if (i != j)
                        {
                            derivatives[i, j] = input_data.Item1[i, j] * 2; //коэффициенты матрицы кавариаций 
                        }
                        else
                        {
                            derivatives[i, j] = input_data.Item1[i, j] * 2; //производная xi^2
                        }
                    }
                    else
                    {
                        if (i < input_data.Item1.GetLength(0))
                        {
                            if (j < input_data.Item1.GetLength(0) + input_data.Item2.GetLength(1) && j >= input_data.Item1.GetLength(0) && !input_data.Item4)//если на max лямба
                            {
                                derivatives[i, j] = input_data.Item2[i, j - input_data.Item1.GetLength(0)] * -1;
                            }
                            if (j < input_data.Item1.GetLength(0) + input_data.Item2.GetLength(1) && j >= input_data.Item1.GetLength(0) && input_data.Item4)//если на min лямба
                            {
                                derivatives[i, j] = input_data.Item2[i, j - input_data.Item1.GetLength(0)] * 1;
                            }
                            if (j == input_data.Item1.GetLength(1) + count2 && input_data.Item4) derivatives[i, j] = -1;//если на max мю 
                            if (j == input_data.Item1.GetLength(1) + count2 && !input_data.Item4) derivatives[i, j] = 1; //если на min мю
                        }
                    }

                    //производные уровнений ограничений целевой функции 
                    if (i >= input_data.Item1.GetLength(0) && i < input_data.Item1.GetLength(0) + input_data.Item2.GetLength(1) && j < input_data.Item1.GetLength(1) && input_data.Item4)
                    {
                        derivatives[i, j] = input_data.Item2[j, i - input_data.Item1.GetLength(0)] * 1;
                    }
                    if (i >= input_data.Item1.GetLength(0) && i < input_data.Item1.GetLength(0) + input_data.Item2.GetLength(1) && j < input_data.Item1.GetLength(1) && !input_data.Item4)
                    {
                        derivatives[i, j] = input_data.Item2[j, i - input_data.Item1.GetLength(0)] * -1;
                    }


                    if (i >= input_data.Item1.GetLength(0) && j == input_data.Item1.GetLength(1) + count2 && !input_data.Item4)
                    {
                        derivatives[i, j] = -1;
                    }
                    if (i >= input_data.Item1.GetLength(0) && j == input_data.Item1.GetLength(1) + count2 && input_data.Item4)
                    {
                        derivatives[i, j] = 1;
                    }
                }
                count2++;
            }

 

            double[,] derivatives_free_сoefficients = new double[derivatives.GetLength(0), derivatives.GetLength(1) + 1];
            int count3 = 0;
            for (int i = 0; i < derivatives_free_сoefficients.GetLength(0); i++)
            {
                for (int j = 0; j < derivatives_free_сoefficients.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        if (i < input_data.Item3.GetLength(0))
                            derivatives_free_сoefficients[i, j] = Math.Abs(input_data.Item3[i]);

                        if (i >= input_data.Item3.GetLength(0))
                            derivatives_free_сoefficients[i, j] = Math.Abs(input_data.Item2[input_data.Item2.GetLength(0) - 1, i - input_data.Item3.GetLength(0)]);
                    }

                    if (i >= input_data.Item3.GetLength(0) && j != 0)
                    {
                        if (input_data.Item2[input_data.Item2.GetLength(0) - 1, i - input_data.Item3.GetLength(0)] > 0)
                            derivatives_free_сoefficients[i, j] = derivatives[i, j - 1] * -1;

                        if (input_data.Item2[input_data.Item2.GetLength(0) - 1, i - input_data.Item3.GetLength(0)] <= 0)
                            derivatives_free_сoefficients[i, j] = derivatives[i, j - 1] * 1;
                    }

                    if (i < input_data.Item3.GetLength(0) && i < derivatives.GetLength(0) && j != 0 && j < derivatives.GetLength(1) + 1)
                    {
                        if (input_data.Item3[i] > 0)
                            derivatives_free_сoefficients[i, j] = derivatives[i, j - 1] * -1;

                        if (input_data.Item3[i] <= 0)
                            derivatives_free_сoefficients[i, j] = derivatives[i, j - 1] * 1;
                    }
                }
            }
            return derivatives_free_сoefficients;
        }

        public Tuple<double[,], List<int>>  Add_Artificial_Variables(double[,] input_table, int number_variables, bool uslovie)
        {
            double[,] derivatives = new double[input_table.GetLength(0), input_table.GetLength(1) + number_variables];
            int count = 0;
            var list_artificial_variables = new List<int>();
            for (int i = 0; i < derivatives.GetLength(0); i++)
            {
                for (int j = 0; j < derivatives.GetLength(1); j++)
                {
                    if (j < input_table.GetLength(1))
                        derivatives[i, j] = input_table[i, j];

                    if (j == input_table.GetLength(1) + count)
                    {
                        derivatives[i, j] = 1;
                        list_artificial_variables.Add(j);
                    }
                }
                count++;
            }

            return Tuple.Create<double[,], List<int>>(derivatives, list_artificial_variables);
        }

        public double[,] Start_table(double[,] derivatives, int number_variables)
        {
            double[,] star_table = new double[derivatives.GetLength(0), derivatives.GetLength(1) + number_variables + 2];

            int count = 0;

            for (int i = 0; i < star_table.GetLength(0); i++)
            {
                for (int j = 0; j < star_table.GetLength(1); j++)
                {
                    if (i < derivatives.GetLength(0) && j < derivatives.GetLength(1))
                        star_table[i, j] = derivatives[i, j];

                    if (j == derivatives.GetLength(1) + count)
                        star_table[i, j] = 1;
                    if (i == star_table.GetLength(0) - 1 && j >= derivatives.GetLength(1) && j < derivatives.GetLength(1) + number_variables)
                        star_table[i, j] = 1;

                }
                count++;
            }
            return star_table;
        }

        public double[,] Simpex_Table(double[,] table)
        {
            double[,] simplex_table = new double[table.GetLength(0) + 1, table.GetLength(1)];
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (i < table.GetLength(0))
                    {
                        simplex_table[i, j] = table[i, j];
                    }
                }
            }
            return simplex_table;
        }

        public List<int> Basis_Variables(double[,] matrix)
        {
            var basis = new List<int>();
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                basis.Add(0);
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (j >= matrix.GetLength(1) - (matrix.GetLength(0) - 1) && matrix[i, j] == 1)
                    {
                        basis[i] = j + 1;
                        break;
                    }
                }
            }
            return basis;
        }



    }
}
