using Simplex_Method;

double[,] table =

{{300,  -200, -200, -40,  -211, -123},
{200,   -100, -40,  -50, - 65,  -45},
{500,   -170, -6,   -34, - 5,   -4},
{300,   -180, -4,   -34, - 6,   -65},
{400,   -40,  -200, 32,  -4,  -140},
{30,   60, 34, 21, 12, 120 },
{10,   30, 41, 32, 23, 22 },
{0,     12,  30,  21,  42,  3 }};

double[] result = new double[5];
double[,] table_result;
SimplexMethod S = new SimplexMethod(table);

table_result = S.Calculate(result);
SimplexMethod.Out(table_result, table.GetLength(0), table.GetLength(1));
Console.WriteLine(); Console.WriteLine("Решение:");
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"X[{i + 1}] = {result[i]}");
}

Console.ReadLine();
