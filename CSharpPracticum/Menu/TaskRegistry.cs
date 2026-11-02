using System.Reflection;

namespace CSharpPracticum.Menu;

public static class TaskRegistry
{
    private static readonly Lazy<IReadOnlyList<Entry>> AllEntries = new(Load);

    public static IReadOnlyList<Entry> All => AllEntries.Value;

    public static IEnumerable<Entry> ForRange(int first, int last) =>
        All.Where(entry => entry.Number >= first && entry.Number <= last);

    private static IReadOnlyList<Entry> Load()
    {
        return typeof(TaskRegistry).Assembly
            .GetTypes()
            .Where(type => type is { IsClass: true, IsAbstract: false } && typeof(ITask).IsAssignableFrom(type))
            .Select(type => new { Type = type, Info = type.GetCustomAttribute<TaskInfoAttribute>() })
            .Where(item => item.Info is not null)
            .Select(item => new Entry(
                item.Info!.Number,
                (ITask)Activator.CreateInstance(item.Type)!,
                item.Info!.Hint))
            .OrderBy(entry => entry.Number)
            .ToList();
    }

    public sealed record Entry(int Number, ITask Instance, string Hint);
}
