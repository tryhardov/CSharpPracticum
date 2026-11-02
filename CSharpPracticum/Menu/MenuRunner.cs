using System.Text;

namespace CSharpPracticum.Menu;

public static class MenuRunner
{
    private static readonly LevelMenu[] Levels =
    [
        new LevelMenu("Уровень 1 — Базовый", 1, 15),
        new LevelMenu("Уровень 2 — Средний", 16, 35),
        new LevelMenu("Уровень 3 — Продвинутый", 36, 50),
    ];

    public static void Run()
    {
        Console.OutputEncoding = Encoding.UTF8;

        try
        {
            while (true)
            {
                PrintMenu();
                string input = ConsoleHelper.ReadLine("Выберите уровень: ").Trim();

                if (input is "4" or "0" or "q" or "Q")
                {
                    Console.WriteLine("До встречи!");
                    return;
                }

                if (int.TryParse(input, out int index) && index >= 1 && index <= Levels.Length)
                {
                    Levels[index - 1].Run();
                }
                else
                {
                    Console.WriteLine("Нет такого пункта, попробуйте ещё раз.");
                }
            }
        }
        catch (EndOfStreamException)
        {
            Console.WriteLine();
            Console.WriteLine("Ввод закрыт. Выход.");
        }
    }

    private static void PrintMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=== Практикум по C# ===");
        for (int i = 0; i < Levels.Length; i++)
        {
            LevelMenu level = Levels[i];
            Console.WriteLine($"{i + 1}. {level.Title} (задания {level.FirstTask}–{level.LastTask})");
        }

        Console.WriteLine($"{Levels.Length + 1}. Выход");
        Console.WriteLine();
    }
}
