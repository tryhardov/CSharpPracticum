using System.Diagnostics;

namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(41, "Task.WhenAll, Task.Delay, async/await, Stopwatch")]
public sealed class Task41_WhenAll : ITask
{
    public string Title => "Task.WhenAll: 10 задач параллельно";

    public string Description => "Сравнить последовательное и параллельное ожидание 10 задач.";

    public string[] Requirements =>
    [
        "Task<int> WorkAsync(int id) с Task.Delay(500)",
        "Последовательно через await в цикле",
        "Параллельно через Task.WhenAll",
        "Замер времени и объяснение",
    ];

    public static async Task<int> WorkAsync(int id)
    {
        await Task.Delay(500);
        return id;
    }

    public void Run() => RunAsync().GetAwaiter().GetResult();

    private static async Task RunAsync()
    {
        var sw = Stopwatch.StartNew();
        var sequential = new List<int>();
        for (int id = 1; id <= 10; id++)
        {
            sequential.Add(await WorkAsync(id));
        }

        TimeSpan sequentialTime = sw.Elapsed;

        sw.Restart();
        int[] parallel = await Task.WhenAll(Enumerable.Range(1, 10).Select(WorkAsync));
        TimeSpan parallelTime = sw.Elapsed;

        Console.WriteLine($"Последовательно: {sequentialTime.TotalMilliseconds:F0} мс");
        Console.WriteLine($"WhenAll:         {parallelTime.TotalMilliseconds:F0} мс");
        Console.WriteLine($"Результаты равны: {sequential.SequenceEqual(parallel)}");
        Console.WriteLine("Вывод: задачи ждут таймер одновременно, поэтому общее время ≈ времени одной (500 мс), а не суммы (5000 мс).");
    }
}
