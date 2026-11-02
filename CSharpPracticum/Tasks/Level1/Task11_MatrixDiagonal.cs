namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(11, "int[,], GetLength, Random.Shared.Next, один цикл for")]
public sealed class Task11_MatrixDiagonal : ITask
{
    public string Title => "Диагональ матрицы N×N";

    public string Description => "Найти сумму элементов главной диагонали случайной матрицы N×N.";

    public string[] Requirements =>
    [
        "N вводит пользователь (минимум 2)",
        "Матрица заполняется случайными числами",
        "Сумма — без LINQ, в одном цикле for",
        "Вывести матрицу и сумму",
    ];

    public static int DiagonalSum(int[,] matrix)
    {
        int sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            sum += matrix[i, i];
        }

        return sum;
    }

    public void Run()
    {
        int n = ConsoleHelper.ReadInt("Размер N (2–15): ", 2, 15);
        int[,] matrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = Random.Shared.Next(1, 100);
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{matrix[i, j],4}");
            }

            Console.WriteLine();
        }

        Console.WriteLine($"Сумма главной диагонали: {DiagonalSum(matrix)}");
    }
}
