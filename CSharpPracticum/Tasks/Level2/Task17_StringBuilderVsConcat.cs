using System.Diagnostics;
using System.Text;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(17, "System.Text.StringBuilder, System.Diagnostics.Stopwatch, оператор +")]
public sealed class Task17_StringBuilderVsConcat : ITask
{
    private const int Count = 10_000;

    public string Title => "StringBuilder vs конкатенация";

    public string Description => "Собрать строку из 10 000 чисел двумя способами и сравнить время.";

    public string[] Requirements =>
    [
        "Конкатенация через + и StringBuilder",
        "Замер Stopwatch, вывод обоих времён и разницы",
        "Объяснение результата в комментарии",
    ];

    public static string BuildWithConcat(int count)
    {
        string result = string.Empty;
        for (int i = 0; i < count; i++)
        {
            result += i + ",";
        }

        return result;
    }

    public static string BuildWithBuilder(int count)
    {
        var builder = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            builder.Append(i).Append(',');
        }

        return builder.ToString();
    }

    public void Run()
    {
        var sw = Stopwatch.StartNew();
        string concat = BuildWithConcat(Count);
        TimeSpan concatTime = sw.Elapsed;

        sw.Restart();
        string built = BuildWithBuilder(Count);
        TimeSpan builderTime = sw.Elapsed;

        Console.WriteLine($"Конкатенация:  {concatTime.TotalMilliseconds:F2} мс");
        Console.WriteLine($"StringBuilder: {builderTime.TotalMilliseconds:F2} мс");
        Console.WriteLine($"Разница:       {(concatTime - builderTime).TotalMilliseconds:F2} мс");
        Console.WriteLine($"Результаты равны: {concat == built}");
        Console.WriteLine("Вывод: + копирует всю строку на каждом шаге (O(n²)), StringBuilder дописывает в буфер (O(n)).");
    }
}
