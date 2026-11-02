using System.Text.RegularExpressions;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(13, "Dictionary<string,int>, Regex.Matches или string.Split, ToLowerInvariant, OrderByDescending")]
public sealed partial class Task13_WordCount : ITask
{
    private const string SampleText =
        "Мама мыла раму. Рама была чистая, мама была довольна! Раму мыла мама, а не папа.";

    public string Title => "Счётчик слов (Dictionary)";

    public string Description => "Посчитать, сколько раз каждое слово встречается в тексте.";

    public string[] Requirements =>
    [
        "Dictionary<string, int>",
        "Разбить текст по пробелам и знакам пунктуации",
        "Слова приводить к нижнему регистру",
        "Вывод «слово → количество» по убыванию количества",
    ];

    public static Dictionary<string, int> CountWords(string text)
    {
        var counts = new Dictionary<string, int>();
        foreach (Match match in WordRegex().Matches(text))
        {
            string word = match.Value.ToLowerInvariant();
            counts[word] = counts.TryGetValue(word, out int current) ? current + 1 : 1;
        }

        return counts;
    }

    public void Run()
    {
        string input = ConsoleHelper.ReadLine("Введите текст (Enter — тестовый текст): ");
        string text = string.IsNullOrWhiteSpace(input) ? SampleText : input;
        Console.WriteLine($"Текст: {text}");
        Console.WriteLine();

        Dictionary<string, int> counts = CountWords(text);
        if (counts.Count == 0)
        {
            Console.WriteLine("В тексте нет слов.");
            return;
        }

        foreach (KeyValuePair<string, int> pair in counts.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
        {
            Console.WriteLine($"{pair.Key} → {pair.Value}");
        }
    }

    [GeneratedRegex(@"[\p{L}\p{N}]+")]
    private static partial Regex WordRegex();
}
