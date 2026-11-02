namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(4, "оператор %, тернарный оператор ? :")]
public sealed class Task04_Parity : ITask
{
    public string Title => "Чётность числа (два способа)";

    public string Description => "Определить, чётное ли введённое число, двумя способами.";

    public string[] Requirements =>
    [
        "Способ 1: % 2 == 0",
        "Способ 2: тернарный оператор ? :",
        "Каждый способ — отдельный метод",
        "Вывести результат обоих способов",
    ];

    public static bool IsEvenByModulo(int n) => n % 2 == 0;

    public static string DescribeByTernary(int n) => n % 2 == 0 ? "чётное" : "нечётное";

    public void Run()
    {
        int n = ConsoleHelper.ReadInt("Введите целое число: ");

        Console.WriteLine($"Способ 1 (%): чётное = {IsEvenByModulo(n)}");
        Console.WriteLine($"Способ 2 (? :): число {DescribeByTernary(n)}");
    }
}
