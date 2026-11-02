namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(33, "System.Linq: OrderByDescending, Take, GroupBy, Average, Where")]
public sealed class Task33_LinqEmployees : ITask
{
    public string Title => "LINQ: сотрудники";

    public string Description => "Top-3 по зарплате, средняя зарплата по отделам, сотрудники старше 30.";

    public string[] Requirements =>
    [
        "Employee: Name, Age, Salary, Department; 10+ записей",
        "Топ-3 по зарплате (убывание)",
        "GroupBy + Average по отделам",
        "Where: старше 30",
    ];

    public void Run()
    {
        List<Employee> employees =
        [
            new("Анна", 28, 120_000m, "IT"),
            new("Борис", 35, 150_000m, "IT"),
            new("Виктор", 42, 90_000m, "Бухгалтерия"),
            new("Галина", 31, 95_000m, "Бухгалтерия"),
            new("Дмитрий", 24, 70_000m, "Поддержка"),
            new("Елена", 39, 110_000m, "Маркетинг"),
            new("Жанна", 45, 180_000m, "IT"),
            new("Захар", 30, 85_000m, "Поддержка"),
            new("Ирина", 27, 100_000m, "Маркетинг"),
            new("Кирилл", 33, 130_000m, "IT"),
        ];

        Console.WriteLine("Топ-3 по зарплате:");
        foreach (Employee e in employees.OrderByDescending(e => e.Salary).Take(3))
        {
            Console.WriteLine($"  {e.Name,-8} {e.Salary,10:N0}");
        }

        Console.WriteLine("Средняя зарплата по отделам:");
        foreach (var group in employees.GroupBy(e => e.Department))
        {
            Console.WriteLine($"  {group.Key,-12} {group.Average(e => e.Salary),10:N0}");
        }

        Console.WriteLine("Старше 30 лет:");
        foreach (Employee e in employees.Where(e => e.Age > 30))
        {
            Console.WriteLine($"  {e.Name,-8} {e.Age}");
        }
    }

    private sealed record Employee(string Name, int Age, decimal Salary, string Department);
}
