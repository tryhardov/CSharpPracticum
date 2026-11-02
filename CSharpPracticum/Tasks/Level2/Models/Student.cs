namespace CSharpPracticum.Tasks.Level2;

public sealed class Student : IComparable<Student>
{
    public Student(string name, double averageGrade)
    {
        Name = name;
        AverageGrade = averageGrade;
    }

    public string Name { get; }

    public double AverageGrade { get; }

    public int CompareTo(Student? other) =>
        other is null ? 1 : other.AverageGrade.CompareTo(AverageGrade);

    public override string ToString() => $"{Name} ({AverageGrade:F1})";
}
