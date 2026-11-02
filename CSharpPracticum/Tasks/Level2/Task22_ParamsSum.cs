namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(22, "params int[], перегрузка метода, IEnumerable<int>")]
public sealed class Task22_ParamsSum : ITask
{
    public string Title => "params-метод + перегрузка";

    public string Description => "Метод суммы с params и его перегрузка для коллекции.";

    public string[] Requirements =>
    [
        "Sum(params int[] numbers)",
        "Перегрузка с той же логикой для готовой коллекции",
        "Вызовы Sum(1, 2, 3), Sum(new[] {1, 2, 3}), Sum()",
        "Пустой вызов возвращает 0",
    ];

    public static int Sum(params int[] numbers) => Sum((IEnumerable<int>)numbers);

    public static int Sum(IEnumerable<int> numbers)
    {
        int total = 0;
        foreach (int n in numbers)
        {
            total += n;
        }

        return total;
    }

    public void Run()
    {
        Console.WriteLine($"Sum(1, 2, 3)              = {Sum(1, 2, 3)}");
        Console.WriteLine($"Sum(new[] {{1, 2, 3}})      = {Sum(new[] { 1, 2, 3 })}");
        Console.WriteLine($"Sum(List<int> {{1, 2, 3}})  = {Sum(new List<int> { 1, 2, 3 })}");
        Console.WriteLine($"Sum()                     = {Sum()}");
    }
}
