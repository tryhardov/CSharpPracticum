using System.Globalization;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(14, "DateTime.TryParseExact, DateTime.AddMonths, TimeSpan.Days")]
public sealed class Task14_Age : ITask
{
    public string Title => "Возраст по дате рождения";

    public string Description => "По дате рождения вычислить точный возраст в годах, месяцах и днях.";

    public string[] Requirements =>
    [
        "Ввод даты через TryParse / TryParseExact",
        "Учесть, что день рождения в этом году мог ещё не наступить",
        "Вывод «X лет, Y месяцев, Z дней»",
        "Некорректная дата — сообщение, без падения",
    ];

    public static (int Years, int Months, int Days) CalculateAge(DateTime birth, DateTime today)
    {
        if (birth.Date > today.Date)
        {
            throw new ArgumentOutOfRangeException(nameof(birth), "Дата рождения в будущем.");
        }

        int totalMonths = ((today.Year - birth.Year) * 12) + today.Month - birth.Month;
        if (birth.Date.AddMonths(totalMonths) > today.Date)
        {
            totalMonths--;
        }

        DateTime anchor = birth.Date.AddMonths(totalMonths);
        int days = (today.Date - anchor).Days;
        return (totalMonths / 12, totalMonths % 12, days);
    }

    public void Run()
    {
        string input = ConsoleHelper.ReadLine("Дата рождения (дд.мм.гггг): ").Trim();
        if (!DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birth))
        {
            Console.WriteLine("Некорректная дата. Нужен формат дд.мм.гггг.");
            return;
        }

        if (birth.Date > DateTime.Today)
        {
            Console.WriteLine("Дата рождения не может быть в будущем.");
            return;
        }

        (int years, int months, int days) = CalculateAge(birth, DateTime.Today);
        Console.WriteLine($"{years} лет, {months} месяцев, {days} дней");
    }
}
