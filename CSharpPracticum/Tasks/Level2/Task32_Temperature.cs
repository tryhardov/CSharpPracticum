namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(32, "свойство с set-валидацией, ArgumentOutOfRangeException, вычисляемое свойство")]
public sealed class Task32_Temperature : ITask
{
    public string Title => "Свойства с валидацией (Temperature)";

    public string Description => "Celsius проверяется в set, Fahrenheit вычисляется.";

    public string[] Requirements =>
    [
        "Celsius не ниже −273.15, иначе ArgumentOutOfRangeException",
        "Fahrenheit — только get",
        "Корректное и некорректное присваивание",
    ];

    public void Run()
    {
        var t = new Temperature { Celsius = 36.6 };
        Console.WriteLine($"{t.Celsius} °C = {t.Fahrenheit:F2} °F");

        t.Celsius = 100;
        Console.WriteLine($"{t.Celsius} °C = {t.Fahrenheit:F2} °F");

        try
        {
            t.Celsius = -300;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.WriteLine($"Значение не изменилось: {t.Celsius} °C");
    }
}
