namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(36, "HashSet<int>.Add/Contains, LINQ GroupBy + Where(g => g.Count() > 1)")]
public sealed class Task36_Duplicates : ITask
{
    public string Title => "Дубликаты в List (HashSet + GroupBy)";

    public string Description => "Найти повторяющиеся числа двумя способами.";

    public string[] Requirements =>
    [
        "Способ 1: HashSet<int> и Contains",
        "Способ 2: LINQ GroupBy",
        "Каждый способ — отдельный метод",
    ];

    public static List<int> FindWithHashSet(IEnumerable<int> numbers)
    {
        var seen = new HashSet<int>();
        var duplicates = new HashSet<int>();
        foreach (int n in numbers)
        {
            if (seen.Contains(n))
            {
                duplicates.Add(n);
            }
            else
            {
                seen.Add(n);
            }
        }

        var result = duplicates.ToList();
        result.Sort();
        return result;
    }

    public static List<int> FindWithGroupBy(IEnumerable<int> numbers) =>
        numbers.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).OrderBy(x => x).ToList();

    public void Run()
    {
        List<int> data = [1, 5, 3, 5, 7, 1, 9, 5, 2, 9];
        Console.WriteLine("Данные: " + string.Join(", ", data));
        Console.WriteLine("HashSet: " + string.Join(", ", FindWithHashSet(data)));
        Console.WriteLine("GroupBy: " + string.Join(", ", FindWithGroupBy(data)));
    }
}
