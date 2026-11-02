using System.Globalization;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(1, "Console.WriteLine, DateTime.Now, ToString(\"dd.MM.yyyy\")")]
public sealed class Task01_HelloWorld : ITask
{
    public string Title => "Hello, World + текущая дата";
    public string Description => "Вывести приветствие и текущую дату.";

    public string[] Requirements =>
    [
        "Использовать Console.WriteLine",
        "Дату получить через DateTime.Now, формат dd.MM.yyyy",
        "Вывести две строки: приветствие и дату",
    ];

    public void Run()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine($"Сегодня: {DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture)}");
    }
}
