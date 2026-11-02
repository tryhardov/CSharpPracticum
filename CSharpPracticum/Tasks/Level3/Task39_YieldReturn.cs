namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(39, "IEnumerable<int>, yield return, foreach, ленивые вычисления")]
public sealed class Task39_YieldReturn : ITask
{
    public string Title => "yield return: генератор чётных чисел";

    public string Description => "Генератор чётных чисел без промежуточного списка.";

    public string[] Requirements =>
    [
        "IEnumerable<int> GetEvenNumbers(int max) через yield return",
        "Использование в foreach",
        "Показать ленивость сообщениями внутри генератора",
    ];

    public static IEnumerable<int> GetEvenNumbers(int max)
    {
        for (int i = 2; i <= max; i += 2)
        {
            yield return i;
        }
    }

    private static IEnumerable<int> GetEvenNumbersVerbose(int max)
    {
        for (int i = 2; i <= max; i += 2)
        {
            Console.WriteLine($"  [генератор] отдаю {i}");
            yield return i;
        }
    }

    public void Run()
    {
        Console.WriteLine("Чётные до 20: " + string.Join(", ", GetEvenNumbers(20)));

        Console.WriteLine("Ленивость (сообщения генератора чередуются с обработкой):");
        foreach (int n in GetEvenNumbersVerbose(8))
        {
            Console.WriteLine($"  [foreach]   получил {n}");
        }
    }
}
