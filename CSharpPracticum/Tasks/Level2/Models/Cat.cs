namespace CSharpPracticum.Tasks.Level2;

public sealed class Cat : Animal
{
    public Cat(string name) : base(name)
    {
    }

    public override string MakeSound() => "Мяу!";
}
