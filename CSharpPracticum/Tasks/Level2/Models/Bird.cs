namespace CSharpPracticum.Tasks.Level2;

public sealed class Bird : Animal
{
    public Bird(string name) : base(name)
    {
    }

    public override string MakeSound() => "Чирик!";

    public string Fly() => $"{Name} взмахивает крыльями и летит.";
}
