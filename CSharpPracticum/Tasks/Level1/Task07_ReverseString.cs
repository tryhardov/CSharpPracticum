namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(7, "char[], цикл for, swap через временную переменную; нельзя Array.Reverse и LINQ")]
public sealed class Task07_ReverseString : ITask
{
    public string Title => "Реверс строки без LINQ";

    public string Description => "Перевернуть введённую строку.";

    public string[] Requirements =>
    [
        "Не использовать Array.Reverse и LINQ",
        "Цикл for (swap в char[])",
        "Пустая строка и один символ обрабатываются корректно",
    ];

    public static string Reverse(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return string.Empty;
        }

        char[] chars = text.ToCharArray();
        for (int i = 0, j = chars.Length - 1; i < j; i++, j--)
        {
            (chars[i], chars[j]) = (chars[j], chars[i]);
        }

        return new string(chars);
    }

    public void Run()
    {
        foreach (string sample in new[] { "abc", "a", string.Empty })
        {
            Console.WriteLine($"\"{sample}\" -> \"{Reverse(sample)}\"");
        }

        string text = ConsoleHelper.ReadLine("Ваша строка: ");
        Console.WriteLine($"Результат: \"{Reverse(text)}\"");
    }
}
