using System.Diagnostics;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(10, "Stopwatch, Random.Shared, Array.Clone; Array.Sort и LINQ нельзя")]
public sealed class Task10_Sorting : ITask
{
    public string Title => "Сортировка пузырьком и вставками";

    public string Description => "Отсортировать массив двумя алгоритмами и замерить время.";

    public string[] Requirements =>
    [
        "BubbleSort и InsertionSort — отдельные методы",
        "Без LINQ и Array.Sort",
        "Замер Stopwatch на массиве из 10 000 элементов",
        "Вывести оба времени",
    ];

    public static void BubbleSort(int[] a)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < a.Length - 1 - i; j++)
            {
                if (a[j] > a[j + 1])
                {
                    (a[j], a[j + 1]) = (a[j + 1], a[j]);
                    swapped = true;
                }
            }

            if (!swapped)
            {
                break;
            }
        }
    }

    public static void InsertionSort(int[] a)
    {
        for (int i = 1; i < a.Length; i++)
        {
            int key = a[i];
            int j = i - 1;
            while (j >= 0 && a[j] > key)
            {
                a[j + 1] = a[j];
                j--;
            }

            a[j + 1] = key;
        }
    }

    public static bool AreEqual(int[] x, int[] y)
    {
        if (x.Length != y.Length)
        {
            return false;
        }

        for (int i = 0; i < x.Length; i++)
        {
            if (x[i] != y[i])
            {
                return false;
            }
        }

        return true;
    }

    public void Run()
    {
        int[] original = new int[10_000];
        for (int i = 0; i < original.Length; i++)
        {
            original[i] = Random.Shared.Next(0, 100_000);
        }

        int[] forBubble = (int[])original.Clone();
        int[] forInsertion = (int[])original.Clone();

        var sw = Stopwatch.StartNew();
        BubbleSort(forBubble);
        sw.Stop();
        long bubbleMs = sw.ElapsedMilliseconds;

        sw.Restart();
        InsertionSort(forInsertion);
        sw.Stop();
        long insertionMs = sw.ElapsedMilliseconds;

        Console.WriteLine($"BubbleSort:    {bubbleMs} мс");
        Console.WriteLine($"InsertionSort: {insertionMs} мс");
        Console.WriteLine($"Результаты одинаковы: {AreEqual(forBubble, forInsertion)}");
    }
}
