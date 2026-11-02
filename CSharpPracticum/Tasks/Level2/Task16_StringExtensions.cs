namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(16, "static class + this string; см. StringExtensions в Tasks/Level2/Models")]
public sealed class Task16_StringExtensions : ITask
{
    public string Title => "Методы расширения для string";

    public string Description => "Написать extension-методы IsPalindrome(), WordCount(), ReverseString().";

    public string[] Requirements =>
    [
        "Статический класс StringExtensions",
        "public static методы с this string первым параметром",
        "Показать вызов на 2–3 строках",
    ];

    public void Run()
    {
        string[] samples = ["abc", "А роза упала на лапу Азора", "Hello, wonderful world!"];
        foreach (string s in samples)
        {
            Console.WriteLine($"\"{s}\"");
            Console.WriteLine($"  IsPalindrome: {s.IsPalindrome()}");
            Console.WriteLine($"  WordCount:    {s.WordCount()}");
            Console.WriteLine($"  Reverse:      {s.ReverseString()}");
        }
    }
}
