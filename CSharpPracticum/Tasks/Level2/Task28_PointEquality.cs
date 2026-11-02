namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(28, "override Equals/GetHashCode, IEquatable<T>, HashCode.Combine, HashSet<T>")]
public sealed class Task28_PointEquality : ITask
{
    public string Title => "Equals / GetHashCode для Point";

    public string Description => "Сделать точки с одинаковыми координатами равными и проверить в HashSet.";

    public string[] Requirements =>
    [
        "Переопределить Equals(object) и GetHashCode()",
        "Реализовать IEquatable<Point>",
        "HashSet<Point> не принимает дубликаты",
    ];

    public void Run()
    {
        var a = new Point(1, 2);
        var b = new Point(1, 2);
        var c = new Point(3, 4);

        Console.WriteLine($"a.Equals(b): {a.Equals(b)}; a == b по ссылке: {ReferenceEquals(a, b)}");
        Console.WriteLine($"Хеши a и b равны: {a.GetHashCode() == b.GetHashCode()}");

        var set = new HashSet<Point>();
        Console.WriteLine($"Add(a): {set.Add(a)}; Add(b): {set.Add(b)}; Add(c): {set.Add(c)}");
        Console.WriteLine($"set.Count = {set.Count} (ожидается 2)");
    }
}
