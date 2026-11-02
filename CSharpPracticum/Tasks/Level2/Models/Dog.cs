namespace CSharpPracticum.Tasks.Level2;

/// <summary>Собака.</summary>
public sealed class Dog : Animal
{
    /// <summary>Создаёт собаку.</summary>
    /// <param name="name">Кличка.</param>
    public Dog(string name) : base(name)
    {
    }

    /// <inheritdoc />
    public override string MakeSound() => "Гав!";
}
