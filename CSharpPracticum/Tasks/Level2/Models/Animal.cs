namespace CSharpPracticum.Tasks.Level2;

public abstract class Animal
{
    protected Animal(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public abstract string MakeSound();

    public override string ToString() => $"{GetType().Name} «{Name}»";
}
