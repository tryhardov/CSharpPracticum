using System.Diagnostics;

namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(37, "рекурсия, Dictionary<int, long>, Stopwatch")]
public sealed class Task37_FibonacciMemo : ITask
{
    public string Title => "Мемоизация Фибоначчи";

    public string Description => "Сравнить обычную рекурсию и рекурсию с Dictionary-кешем.";

    public string[] Requirements =>
    [
        "Обычная рекурсивная версия",
        "Версия с Dictionary<int, long>",
        "Замер на N = 35, вывод времён и разницы",
    ];

    public static long Fib(int n) => n < 2 ? n : Fib(n - 1) + Fib(n - 2);

    public static long FibMemo(int n) => FibMemo(n, new Dictionary<int, long>());

    private static long FibMemo(int n, Dictionary<int, long> cache)
    {
        if (n < 2)
        {
            return n;
        }

        if (cache.TryGetValue(n, out long cached))
        {
            return cached;
        }

        long result = FibMemo(n - 1, cache) + FibMemo(n - 2, cache);
        cache[n] = result;
        return result;
    }

    public void Run()
    {
        const int n = 35;
        var sw = Stopwatch.StartNew();
        long plain = Fib(n);
        TimeSpan plainTime = sw.Elapsed;

        sw.Restart();
        long memo = FibMemo(n);
        TimeSpan memoTime = sw.Elapsed;

        Console.WriteLine($"Fib({n}) = {plain}, рекурсия:   {plainTime.TotalMilliseconds:F3} мс");
        Console.WriteLine($"Fib({n}) = {memo}, мемоизация: {memoTime.TotalMilliseconds:F3} мс");
        Console.WriteLine($"Разница: {(plainTime - memoTime).TotalMilliseconds:F3} мс; результаты равны: {plain == memo}");
    }
}
