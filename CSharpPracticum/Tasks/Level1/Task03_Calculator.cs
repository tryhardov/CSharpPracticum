using System.Globalization;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(3, "switch, double.TryParse (через ConsoleHelper.ReadDouble), if для проверки делителя")]
public sealed class Task03_Calculator : ITask
{
    public string Title => "Калькулятор с делением на ноль";

    public string Description => "Принимает два числа и оператор (+, -, *, /) и выводит результат.";

    public string[] Requirements =>
    [
        "Оператор обрабатывать через switch",
        "Деление на ноль — сообщение об ошибке, без падения",
        "Некорректный оператор — «Неизвестная операция»",
        "Числа вводить через TryParse",
    ];

    public static string Calculate(double a, string op, double b)
    {
        switch (op)
        {
            case "+":
                return Format(a + b);
            case "-":
                return Format(a - b);
            case "*":
                return Format(a * b);
            case "/":
                return b == 0 ? "Ошибка: деление на ноль" : Format(a / b);
            default:
                return "Неизвестная операция";
        }
    }

    public void Run()
    {
        double a = ConsoleHelper.ReadDouble("Первое число: ");
        string op = ConsoleHelper.ReadLine("Оператор (+ - * /): ").Trim();
        double b = ConsoleHelper.ReadDouble("Второе число: ");

        Console.WriteLine($"Результат: {Calculate(a, op, b)}");
    }

    private static string Format(double value) => value.ToString("G15", CultureInfo.InvariantCulture);
}
