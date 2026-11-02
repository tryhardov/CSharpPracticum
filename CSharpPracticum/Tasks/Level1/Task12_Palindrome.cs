namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(12, "char.IsLetterOrDigit, ToLowerInvariant, два указателя; LINQ Reverse нельзя")]
public sealed class Task12_Palindrome : ITask
{
    public string Title => "Палиндром (без учёта регистра и пробелов)";

    public string Description => "Проверить, является ли строка палиндромом.";

    public string[] Requirements =>
    [
        "Игнорировать регистр",
        "Игнорировать пробелы и знаки пунктуации",
        "Не использовать LINQ Reverse",
        "Пустая строка и один символ — палиндром",
    ];

    public static bool IsPalindrome(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return true;
        }

        var letters = new List<char>();
        foreach (char ch in text)
        {
            if (char.IsLetterOrDigit(ch))
            {
                letters.Add(char.ToLowerInvariant(ch));
            }
        }

        for (int i = 0, j = letters.Count - 1; i < j; i++, j--)
        {
            if (letters[i] != letters[j])
            {
                return false;
            }
        }

        return true;
    }
    public void Run()
    {
        foreach (string sample in new[] { "А роза упала на лапу Азора", "hello", string.Empty, "a" })
        {
            Console.WriteLine($"\"{sample}\" -> {IsPalindrome(sample)}");
        }

        string text = ConsoleHelper.ReadLine("Ваша строка: ");
        Console.WriteLine($"Палиндром: {IsPalindrome(text)}");
    }
}
