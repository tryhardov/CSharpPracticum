namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(25, "interface IShape, List<T>.Sort(Comparison<T>), Math.PI, формула Герона")]
public sealed class Task25_Shapes : ITask
{
    public string Title => "IShape и сортировка фигур";

    public string Description => "Реализовать фигуры и отсортировать их по площади.";

    public string[] Requirements =>
    [
        "IShape: Area(), Perimeter()",
        "Circle, Rectangle, Triangle",
        "List<IShape> из 5+ фигур",
        "Сортировка по площади, вывод до и после",
    ];

    public void Run()
    {
        var shapes = new List<IShape>
        {
            new Circle(2), new Rectangle(3, 4), new Triangle(3, 4, 5),
            new Circle(0.5), new Rectangle(10, 1), new Triangle(6, 6, 6),
        };

        Console.WriteLine("До сортировки:");
        Print(shapes);

        shapes.Sort((a, b) => a.Area().CompareTo(b.Area()));

        Console.WriteLine("После сортировки по площади:");
        Print(shapes);
    }

    private static void Print(IEnumerable<IShape> shapes)
    {
        foreach (IShape shape in shapes)
        {
            Console.WriteLine($"  {shape,-28} S={shape.Area(),8:F2}  P={shape.Perimeter(),7:F2}");
        }
    }
}
