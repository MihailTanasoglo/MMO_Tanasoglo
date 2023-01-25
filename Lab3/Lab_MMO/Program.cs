using System;
namespace Lab_MMO
{
    class Program
    {
        static void Main(string[] args)
        {
            Input_Data input = new Input_Data();

            while (true)
            {
                Console.WriteLine("1. смешаная стратегия");
                Console.WriteLine("2. чистая стратегия");
                string key3 = Console.ReadLine();
                Console.WriteLine();
                if (key3 == "1")
                {
                    Matrix_Game matix_game = new Matrix_Game(input.Input_Matrix_Game_Problem_2());
                    break;
                }
                else
                {
                    Matrix_Game matix_game = new Matrix_Game(input.Input_Matrix_Game_Problem());
                    break;
                }
            }
                Console.WriteLine();
                Console.WriteLine("Нажмите любую кнопку для выхода в меню");
                Console.ReadLine();
                Console.Clear();
        }
    }
}
