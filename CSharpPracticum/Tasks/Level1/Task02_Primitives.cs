using System.Globalization;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(2, "int, long, double, float (f), decimal (m), bool, char, string, GetType().Name")]
public sealed class Task02_Primitives : ITask
{
    public string Title => "Переменные примитивных типов";

    public string Description => "Объявить переменные примитивных типов и вывести значение и тип каждой.";

    public string[] Requirements =>
    [
        "Минимум: int, long, double, float, decimal, bool, char, string",
        "Для каждой переменной вывести значение и GetType().Name",
        "decimal — с суффиксом m, float — с суффиксом f",
    ];

    public void Run()
    {
        int intValue = 42;
        long longValue = 9_000_000_000L;
        double doubleValue = 3.14159265358979;
        float floatValue = 2.71828f;
        decimal decimalValue = 19.99m;
        bool boolValue = true;
        char charValue = 'A';
        string stringValue = "Привет, C#!";
        byte byteValue = 255;
        short shortValue = -32000;

        Print(nameof(intValue), intValue);
        Print(nameof(longValue), longValue);
        Print(nameof(doubleValue), doubleValue);
        Print(nameof(floatValue), floatValue);
        Print(nameof(decimalValue), decimalValue);
        Print(nameof(boolValue), boolValue);
        Print(nameof(charValue), charValue);
        Print(nameof(stringValue), stringValue);
        Print(nameof(byteValue), byteValue);
        Print(nameof(shortValue), shortValue);
    }

    private static void Print<T>(string name, T value) where T : notnull
    {
        string text = Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty;
        Console.WriteLine($"{name} = {text} ({value.GetType().Name})");
    }
}
