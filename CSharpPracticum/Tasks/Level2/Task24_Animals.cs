namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(24, "abstract class, override, наследование, List<Animal>, pattern matching (is Bird)")]
public sealed class Task24_Animals : ITask
{
    public string Title => "ООП: Animal → Dog/Cat/Bird";

    public string Description => "Построить иерархию животных и показать полиморфизм.";

    public string[] Requirements =>
    [
        "Абстрактный Animal: Name, abstract MakeSound(), ToString()",
        "Dog, Cat, Bird; у Bird дополнительно Fly()",
        "List<Animal> и вызов MakeSound() в цикле",
    ];

    public void Run()
    {
        var animals = new List<Animal> { new Dog("Рекс"), new Cat("Мурка"), new Bird("Кеша") };
        foreach (Animal animal in animals)
        {
            Console.WriteLine($"{animal} говорит: {animal.MakeSound()}");
            if (animal is Bird bird)
            {
                Console.WriteLine($"  {bird.Fly()}");
            }
        }
    }
}
