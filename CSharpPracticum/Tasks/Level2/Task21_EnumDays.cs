namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(21, "enum, switch expression, Enum.GetValues<T>()")]
public sealed class Task21_EnumDays : ITask
{
    public string Title => "enum: дни недели";

    public string Description => "Описать дни недели через enum, определить выходные и русские названия.";

    public string[] Requirements =>
    [
        "enum DayOfWeek (Monday … Sunday)",
        "IsWeekend(DayOfWeek) и GetRussianName(DayOfWeek)",
        "Показать все 7 дней",
    ];

    public static bool IsWeekend(DayOfWeek day) => day is DayOfWeek.Saturday or DayOfWeek.Sunday;

    public static string GetRussianName(DayOfWeek day) => day switch
    {
        DayOfWeek.Monday => "Понедельник",
        DayOfWeek.Tuesday => "Вторник",
        DayOfWeek.Wednesday => "Среда",
        DayOfWeek.Thursday => "Четверг",
        DayOfWeek.Friday => "Пятница",
        DayOfWeek.Saturday => "Суббота",
        DayOfWeek.Sunday => "Воскресенье",
        _ => throw new ArgumentOutOfRangeException(nameof(day), day, null),
    };

    public void Run()
    {
        foreach (DayOfWeek day in Enum.GetValues<DayOfWeek>())
        {
            Console.WriteLine($"{day,-10} {GetRussianName(day),-12} выходной: {(IsWeekend(day) ? "да" : "нет")}");
        }
    }
}
