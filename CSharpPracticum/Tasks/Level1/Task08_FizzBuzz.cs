namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(8, "цикл for, оператор %, if / else if (сначала проверка на 15)")]
public sealed class Task08_FizzBuzz : ITask
{
    public string Title => "FizzBuzz 1–100";

    public string Description => "Вывести числа от 1 до 100, заменяя кратные 3, 5 и 15.";

    public string[] Requirements =>
    [
        "Кратно 3 — Fizz, кратно 5 — Buzz, кратно 15 — FizzBuzz",
        "Иначе — само число",
        "Сначала проверять 15, потом 3 и 5",
    ];

    public static string FizzBuzzOf(int n)
    {
        if (n % 15 == 0)
        {
            return "FizzBuzz";
        }

        if (n % 3 == 0)
        {
            return "Fizz";
        }

        if (n % 5 == 0)
        {
            return "Buzz";
        }

        return n.ToString();
    }

    public void Run()
    {
        for (int i = 1; i <= 100; i++)
        {
            Console.Write($"{FizzBuzzOf(i),-9}");
            if (i % 10 == 0)
            {
                Console.WriteLine();
            }
        }
    }
}
