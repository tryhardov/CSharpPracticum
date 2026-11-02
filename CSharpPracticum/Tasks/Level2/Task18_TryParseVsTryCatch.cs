namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(18, "int.TryParse(out), int.Parse + try/catch (FormatException, OverflowException)")]
public sealed class Task18_TryParseVsTryCatch : ITask
{
    public string Title => "TryParse vs try/catch";

    public string Description => "Сравнить два способа безопасного разбора числа.";

    public string[] Requirements =>
    [
        "Способ 1: int.TryParse с out",
        "Способ 2: int.Parse в try/catch (FormatException)",
        "Каждый способ — отдельный метод",
        "Показать на «123» и «abc»",
    ];

    public static bool ParseWithTryParse(string? input, out int value) => int.TryParse(input, out value);

    public static bool ParseWithTryCatch(string? input, out int value)
    {
        try
        {
            value = int.Parse(input!);
            return true;
        }
        catch (FormatException)
        {
            value = 0;
            return false;
        }
        catch (Exception ex) when (ex is OverflowException or ArgumentNullException)
        {
            value = 0;
            return false;
        }
    }

    public void Run()
    {
        foreach (string input in new[] { "123", "abc" })
        {
            bool ok1 = ParseWithTryParse(input, out int v1);
            bool ok2 = ParseWithTryCatch(input, out int v2);
            Console.WriteLine($"\"{input}\": TryParse → {ok1}/{v1}; try/catch → {ok2}/{v2}");
        }

        Console.WriteLine("TryParse быстрее и чище: исключения дороги и не нужны для ожидаемой ошибки ввода.");
    }
}
