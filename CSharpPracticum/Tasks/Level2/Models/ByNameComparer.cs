namespace CSharpPracticum.Tasks.Level2;

public sealed class ByNameComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y) =>
        string.Compare(x?.Name, y?.Name, StringComparison.CurrentCultureIgnoreCase);
}
