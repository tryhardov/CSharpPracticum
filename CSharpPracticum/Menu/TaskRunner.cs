namespace CSharpPracticum.Menu;

public static class TaskRunner
{
    private const int Width = 50;

    public static void Run(TaskRegistry.Entry entry)
    {
        ITask task = entry.Instance;

        Console.WriteLine();
        Console.WriteLine(new string('=', Width));
        Console.WriteLine($"Задание {entry.Number}. {task.Title}");
        Console.WriteLine(new string('-', Width));
        Console.WriteLine("Описание:");
        Console.WriteLine($"  {task.Description}");
        Console.WriteLine();
        Console.WriteLine("Требования:");
        foreach (string requirement in task.Requirements)
        {
            Console.WriteLine($"  - {requirement}");
        }

        Console.WriteLine();
        Console.WriteLine("Подсказка (что можно использовать):");
        Console.WriteLine($"  {entry.Hint}");
        Console.WriteLine(new string('-', Width));
        Console.WriteLine("[запуск решения...]");
        Console.WriteLine();

        try
        {
            task.Run();
        }
        catch (EndOfStreamException)
        {
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Необработанная ошибка в задании: {ex.Message}");
        }

        Console.WriteLine();
        Console.Write("Нажмите Enter для возврата в меню...");
        Console.ReadLine();
    }
}
