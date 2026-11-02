namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(27, "IComparable<T>, IComparer<T>, List<T>.Sort() и Sort(IComparer<T>)")]
public sealed class Task27_Comparers : ITask
{
    public string Title => "IComparable / IComparer для Student";

    public string Description => "Научить Student сортироваться двумя способами.";

    public string[] Requirements =>
    [
        "Student: Name, AverageGrade",
        "IComparable<Student> — по среднему баллу по убыванию",
        "ByNameComparer : IComparer<Student> — по имени",
    ];

    public void Run()
    {
        var students = new List<Student>
        {
            new("Борис", 4.2), new("Анна", 4.9), new("Виктор", 3.8), new("Галина", 4.5),
        };

        students.Sort();
        Console.WriteLine("По среднему баллу (убывание): " + string.Join(", ", students));

        students.Sort(new ByNameComparer());
        Console.WriteLine("По имени:                     " + string.Join(", ", students));
    }
}
