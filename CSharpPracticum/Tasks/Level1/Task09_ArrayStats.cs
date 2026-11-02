using System.Globalization;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(9, "int[], Random.Shared.Next, цикл foreach; Min/Max/Sum/Average из LINQ нельзя")]
public sealed class Task09_ArrayStats : ITask
{
    public string Title => "Массивы: min / max / sum / avg";

    public string Description => "Для массива чисел найти минимум, максимум, сумму и среднее без LINQ.";

    public string[] Requirements =>
    [
        "Массив из 20 случайных чисел 1–100",
        "Без LINQ (Min/Max/Sum/Average запрещены)",
        "4 отдельных метода",
        "Пустой массив не должен приводить к падению",
    ];

    public static int? FindMin(int[] values)
    {
        if (values.Length == 0)
        {
            return null;
        }

        int min = values[0];
        foreach (int v in values)
        {
            if (v < min)
            {
                min = v;
            }
        }

        return min;
    }

    public static int? FindMax(int[] values)
    {
        if (values.Length == 0)
        {
            return null;
        }

        int max = values[0];
        foreach (int v in values)
        {
            if (v > max)
            {
                max = v;
            }
        }

        return max;
    }

    public static long FindSum(int[] values)
    {
        long sum = 0;
        foreach (int v in values)
        {
            sum += v;
        }

        return sum;
    }

    public static double? FindAverage(int[] values) =>
        values.Length == 0 ? null : (double)FindSum(values) / values.Length;

    public void Run()
    {
        int[] numbers = new int[20];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = Random.Shared.Next(1, 101);
        }

        Report("Случайный массив", numbers);
        Report("Пустой массив", []);
    }

    private static void Report(string title, int[] values)
    {
        Console.WriteLine($"{title}: [{string.Join(", ", values)}]");
        Console.WriteLine($"  min = {Show(FindMin(values))}");
        Console.WriteLine($"  max = {Show(FindMax(values))}");
        Console.WriteLine($"  sum = {FindSum(values)}");
        Console.WriteLine($"  avg = {Show(FindAverage(values))}");
    }

    private static string Show<T>(T? value) where T : struct =>
        value is null ? "нет данных" : Convert.ToString(value.Value, CultureInfo.InvariantCulture) ?? string.Empty;
}
