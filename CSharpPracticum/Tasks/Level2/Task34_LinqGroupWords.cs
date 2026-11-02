namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(34, "GroupBy(w => w[0]), OrderBy, string.Join, StringComparer")]
public sealed class Task34_LinqGroupWords : ITask
{
    public string Title => "LINQ: группировка слов по букве";

    public string Description => "Сгруппировать слова по первой букве и отсортировать.";

    public string[] Requirements =>
    [
        "Список из 10+ слов",
        "GroupBy(w => w[0]), группы по алфавиту",
        "Слова внутри группы по алфавиту",
        "Вывод «Буква: слово1, слово2, ...»",
    ];
    public static IEnumerable<string> Group(IEnumerable<string> words) =>
        words
            .Where(w => !string.IsNullOrEmpty(w))
            .GroupBy(w => char.ToUpperInvariant(w[0]))
            .OrderBy(g => g.Key)
            .Select(g => $"{g.Key}: {string.Join(", ", g.OrderBy(w => w, StringComparer.CurrentCultureIgnoreCase))}");

    public void Run()
    {
        string[] words =
        [
            "яблоко",
            "арбуз",
            "банан",
            "виноград",
            "ананас",
            "апельсин",
            "брусника",
            "вишня",
            "груша",
            "гранат",
            "абрикос",
            "ягода",
        ];

        foreach (string line in Group(words))
        {
            Console.WriteLine(line);
        }
    }
}
