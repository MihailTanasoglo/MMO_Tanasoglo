using System;

namespace Lab_MMO
{
    public class Input_Data
    {
        public Tuple<double[,], string[], bool, bool> Input_Linear_Programming()
        {
            double[,] table = { {80,  74,  83,   75,  82,  85},
                                {10,  12,   9,    7,   8,  11},
                                { 5,   7,   3,    8,   4,   2},
                                { 5,   7,   5,   10,   6,   2},
                                { 1,   1,   1,    1,   1,   1},
                                { 0, 3.5, 4.6,  3.1, 4.2, 4.8}};

            string[] compare = { "<=", "<=", "<=", ">=", "=" };

            //false max, true min
            bool uslovie = true;

            bool uslovie2 = false;
            return Tuple.Create(table, compare, uslovie, uslovie2);
        }
        public Tuple<double[,], string[], bool, bool> Input_Linear_Programming_2()
        {


            double[,] table = { {200,  5,  2,  4,  3,  7},
                                {300,  3,  3,  1,  3,  4},
                                {150,  2,  6,  3,  5,  2},
                                {100,  0,  3,  3,  2,  1},
                                { 75,  2,  2,  2,  5,  3},
                                {  0,  3,  4,  1,  5,  3}};

            string[] compare = { "<=", "<=", "<=", "<=", "<=" };

            //false max, true min
            bool uslovie = false;

            bool uslovie2 = false;
            return Tuple.Create(table, compare, uslovie, uslovie2);
        }

        public Tuple<double[,], bool> Input_Transportation_Problem()
        {
            // Сбалансированая задача
            double[,] table = {{    0, 1000, 900, 800, 900, 800, 400 },
                               {  900,  15,  18,  22,  19,  20,  10 },
                               { 1400,  19,  22,  19,  18,  17,  12 },
                               {  700,  26,  18,  20,  24,  21,  10 },
                               { 1000,  21,  16,  26,  19,  23,  16 },
                               {  800,  11,  17,  22,  17,  19,  11 },
                               };
            //false max, true min
            bool uslovie = false;
            return Tuple.Create(table, uslovie);
        }
        public Tuple<double[,], bool> Input_Transportation_Problem_2()
        {
            //Не сбалансированная задача
            double[,] table = {{    0, 1000, 900, 800, 900, 800, 400 },
                               {  900,  15,  18,  22,  19,  20,  10 },
                               { 1400,  19,  22,  19,  18,  17,  12 },
                               {  600,  26,  18,  21,  24,  21,  10 },
                               { 1000,  21,  16,  25,  19,  23,  16 },
                               {  700,  11,  17,  22,  17,  19,  11 },
                              };

            //false max, true min
            bool uslovie = false;
            return Tuple.Create(table, uslovie);
        }

        public double[,] Input_Matrix_Game_Problem()
        {
            double[,] table = {{ 3, 9, 2, 1},
                              { 7, 8, 5, 6},
                              { 4, 7, 3, 5},
                              { 5, 6, 1, 7}
                             };
            return table;
        }
    public double[,] Input_Matrix_Game_Problem_2()
    {
        double[,] table = { { 5,  6 , 7},
                                { 4,  2,  4},
                                { 3,  1,  5},
                                { 4,  6 , 8},
                                { 5,  9, 12},
                                { 7,  8 , 3}};
        return table;
    }

    public Tuple<double[,], double[,], double[], bool> Input_Markowitz_Portfolio()
    {
            double[,] matrix = {{ 0.11, -0.07, -0.06, -0.08},
                            {-0.07,  0.17, -0.03, -0.01},
                            {-0.06, -0.03,  0.38,  0.05},
                            {-0.08, -0.01,  0.05,  0.32}
                           };
            double[,] restriction_conditions = {    {   1,  0.07 },
                                                {   1, -0.22 },
                                                {   1,  0.17 },
                                                {   1,  0.32 },
                                                {2000,  1500  }
                                           };
            double[] free_odds = { 0, 0, 0, 0 };
            bool uslovie = false;




            //double[,] matrix = {{ -2, -1},
            //                    { -1, -2},
            //                   };
            //double[,] restriction_conditions = {{   1 },
            //                                    {   2 },
            //                                    {   2 },
            //                                   };
            //double[] free_odds = { 4, 6 };

            //bool uslovie = false;

            //double[,] matrix = {{ -1, 0},
            //                    { 0, -1},
            //                   };
            //double[,] restriction_conditions = {{   1 },
            //                                    {   1 },
            //                                    {   4 },
            //                                   };
            //double[] free_odds = { 4, 2 };

            //double[,] matrix = {{ -1, 0},
            //                        { 0,  0},
            //                       };
            //double[,] restriction_conditions = {{   3 ,2 ,1},
            //                                        {   2 ,9,0},
            //                                        {   18 ,36,5},
            //                                       };
            //double[] free_odds = { 6, 3 };

            //bool uslovie = false;

            //double[,] matrix = {{ -2, -1,  4},
            //                    { -1, -2,  6},
            //                    {  4,  6, -2}
            //                   };
            //double[,] restriction_conditions = {{   1, 3 },
            //                                    {   2, 2 },
            //                                    {   2, 7 },
            //                                    {   4, 8 }
            //                                   };
            //double[] free_odds = { 4, 6, 8 };

            //bool uslovie = false;
            return Tuple.Create(matrix, restriction_conditions, free_odds, uslovie);
    }

}
}
