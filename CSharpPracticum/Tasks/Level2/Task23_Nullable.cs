namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(23, "int?, HasValue/Value, оператор ??, оператор ?., Dictionary.TryGetValue")]
public sealed class Task23_Nullable : ITask
{
    private static readonly Dictionary<string, int> Storage = new() { ["age"] = 30, ["count"] = 5 };

    public string Title => "Nullable: ??, ?., HasValue";

    public string Description => "Показать работу с nullable-типами и безопасный доступ к null.";

    public string[] Requirements =>
    [
        "int? FindValue(string key) возвращает null, если ключа нет",
        "?? для значения по умолчанию",
        "?. для безопасного доступа к свойству",
        "HasValue / Value с проверкой",
    ];

    public static int? FindValue(string key) => Storage.TryGetValue(key, out int value) ? value : null;

    public void Run()
    {
        foreach (string key in new[] { "age", "missing" })
        {
            int? found = FindValue(key);
            Console.WriteLine($"[{key}] HasValue={found.HasValue}, ?? -1 → {found ?? -1}");
            if (found.HasValue)
            {
                Console.WriteLine($"[{key}] Value = {found.Value}");
            }
        }

        Person? withCity = new("Аня", new Address("Волгоград"));
        Person? withoutAddress = new("Борис", null);
        Person? nobody = null;
        foreach (Person? person in new[] { withCity, withoutAddress, nobody })
        {
            Console.WriteLine($"Город: {person?.Address?.City ?? "неизвестно"}");
        }
    }

    private sealed record Address(string City);

    private sealed record Person(string Name, Address? Address);
}
