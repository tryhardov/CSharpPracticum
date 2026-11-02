namespace CSharpPracticum.Menu;

public sealed class LevelMenu
{
    public LevelMenu(string title, int firstTask, int lastTask)
    {
        Title = title;
        FirstTask = firstTask;
        LastTask = lastTask;
    }

    public string Title { get; }

    public int FirstTask { get; }

    public int LastTask { get; }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine($"--- {Title} ---");
            foreach (TaskRegistry.Entry entry in TaskRegistry.ForRange(FirstTask, LastTask))
            {
                Console.WriteLine($"{entry.Number,2}. {entry.Instance.Title}");
            }

            Console.WriteLine(" 0. Назад");
            Console.WriteLine();

            string input = ConsoleHelper.ReadLine("Выберите задание: ").Trim();
            if (input is "0" or "q" or "Q")
            {
                return;
            }

            TaskRegistry.Entry? selected = null;
            if (int.TryParse(input, out int number))
            {
                selected = TaskRegistry.ForRange(FirstTask, LastTask).FirstOrDefault(e => e.Number == number);
            }

            if (selected is null)
            {
                Console.WriteLine("Нет такого задания в этом уровне.");
                continue;
            }

            TaskRunner.Run(selected);
        }
    }
}
