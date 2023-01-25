using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lab_MMO
{
  public static class Data_Output
    {
         public static void Reference_Plan(double[,] table)
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Опорный план");
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (i != 0)
                    Console.WriteLine();
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j] != 0)
                        Console.Write("{0,6}  |", table[i, j].ToString("0.00", CultureInfo.InvariantCulture));
                    else Console.Write("{0,6}  |", table[i, j]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------");
        }

        public static void Basic_Simplex_Table(double[,] table)
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Базовая Симплекс таблица:");
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (i != 0)
                    Console.WriteLine();
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j] != 0)
                        Console.Write("{0,6}  |", table[i, j].ToString("0.00", CultureInfo.InvariantCulture));
                    else Console.Write("{0,6}  |", table[i, j]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------");
        }

        public static void Basis_Simplex_Table(double[,] table)
        {
            string str;
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Симплекс таблица после нахождения базиса:");
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (i != 0)
                    Console.WriteLine();
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j] != 0)
                        Console.Write("{0,6}  |", table[i, j].ToString("0.00", CultureInfo.InvariantCulture));
                    else Console.Write("{0,6}  |", table[i, j]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------");
        }

        public static void Calculation_Simplex_Table(double[,] table, int iteratia,int row,int col)
        {
          
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Разрешающий столбец: {0}", col);
            Console.WriteLine("Разрешающая строка:  {0}", row);
            Console.WriteLine();

            Console.WriteLine("Вторая фаза Симплекс таблица после {0} итерации:", iteratia);
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (i != 0)
                    Console.WriteLine();
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j] != 0)
                        Console.Write("{0,6}  |", table[i, j].ToString("0.00", CultureInfo.InvariantCulture));
                    else Console.Write("{0,6}  |", table[i, j]);
                }
            }
         
        }

        public static void Calculation_Simplex_Table_2(double[,] table, int iteratia, int row, int col)
        {

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Разрешающий столбец: {0}", col);
            Console.WriteLine("Разрешающая строка:  {0}", row);
            Console.WriteLine();

            Console.WriteLine(" Первая фаза Симплекс таблица после {0} итерации:", iteratia);
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (i != 0)
                    Console.WriteLine();
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j] != 0)
                        Console.Write("{0,6}  |", table[i, j].ToString("0.00", CultureInfo.InvariantCulture));
                    else Console.Write("{0,6}  |", table[i, j]);
                }
            }

        }


        public static void Derivatives(double[,] table)
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Производные + KKT:");
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (i != 0)
                    Console.WriteLine();
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if(table[i, j]!=0)
                    Console.Write("{0,6}  |", table[i, j].ToString("0.00", CultureInfo.InvariantCulture));
                    else Console.Write("{0,6}  |", table[i, j]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }
}
