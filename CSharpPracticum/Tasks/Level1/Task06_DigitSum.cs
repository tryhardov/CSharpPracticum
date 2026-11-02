namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(6, "ToString(), int.Parse, цикл while, Math.Abs, остаток и целочисленное деление")]
public sealed class Task06_DigitSum : ITask
{
    public string Title => "Сумма цифр числа";

    public string Description => "Найти сумму цифр числа (1234 → 10) двумя способами.";

    public string[] Requirements =>
    [
        "Способ 1: ToString() → символы → int.Parse",
        "Способ 2: while (n > 0) { sum += n % 10; n /= 10; }",
        "Каждый способ — отдельный метод",
        "Отрицательные числа — брать модуль",
    ];

    public static int SumByString(long n)
    {
        int sum = 0;
        foreach (char ch in Math.Abs(n).ToString())
        {
            sum += int.Parse(ch.ToString());
        }

        return sum;
    }
    public static int SumByArithmetic(long n)
    {
        long rest = Math.Abs(n);
        int sum = 0;
        while (rest > 0)
        {
            sum += (int)(rest % 10);
            rest /= 10;
        }

        return sum;
    }

    public void Run()
    {
        long[] samples = [1234, -9875, 0];
        foreach (long sample in samples)
        {
            Console.WriteLine($"{sample}: строка = {SumByString(sample)}, арифметика = {SumByArithmetic(sample)}");
        }

        int n = ConsoleHelper.ReadInt("Ваше число: ");
        Console.WriteLine($"{n}: строка = {SumByString(n)}, арифметика = {SumByArithmetic(n)}");
    }
}
