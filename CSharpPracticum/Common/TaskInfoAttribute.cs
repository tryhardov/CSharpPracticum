namespace CSharpPracticum.Common;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class TaskInfoAttribute : Attribute
{
    public TaskInfoAttribute(int number, string hint)
    {
        Number = number;
        Hint = hint;
    }

    public int Number { get; }

    public string Hint { get; }
}
