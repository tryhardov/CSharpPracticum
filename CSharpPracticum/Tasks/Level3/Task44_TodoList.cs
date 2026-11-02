namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(44, "System.Text.Json (JsonSerializer), File.ReadAllText/WriteAllText, классы TaskItem/TaskRepository/TaskService")]
public sealed class Task44_TodoList : ITask
{
    private const string FileName = "tasks.json";

    public string Title => "Мини-проект «Todo List» (JSON)";

    public string Description => "Консольный список задач с сохранением в tasks.json.";

    public string[] Requirements =>
    [
        "TaskItem, TaskRepository (CRUD), TaskService",
        "Добавить, показать, отметить выполненной, удалить",
        "Сохранение между запусками через System.Text.Json",
        "Обработка некорректного ввода и повреждённого/отсутствующего файла",
    ];

    public void Run()
    {
        var repository = new TaskRepository(Path.Combine(Environment.CurrentDirectory, FileName));
        if (repository.LoadWarning is not null)
        {
            Console.WriteLine(repository.LoadWarning);
        }

        var service = new TaskService(repository);

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Показать  2. Добавить  3. Отметить выполненной  4. Удалить  0. Назад");
            string choice = ConsoleHelper.ReadLine("Действие: ").Trim();

            switch (choice)
            {
                case "1":
                    Print(service.GetAll());
                    break;
                case "2":
                    Add(service);
                    break;
                case "3":
                    int doneId = ConsoleHelper.ReadInt("Id задачи: ");
                    Console.WriteLine(service.MarkDone(doneId) ? "Готово." : "Задача не найдена.");
                    break;
                case "4":
                    int deleteId = ConsoleHelper.ReadInt("Id задачи: ");
                    Console.WriteLine(service.Delete(deleteId) ? "Удалено." : "Задача не найдена.");
                    break;
                case "0" or "q" or "Q":
                    return;
                default:
                    Console.WriteLine("Неизвестное действие.");
                    break;
            }
        }
    }

    private static void Add(TaskService service)
    {
        try
        {
            TaskItem item = service.Add(ConsoleHelper.ReadLine("Название: "));
            Console.WriteLine($"Добавлена задача #{item.Id}.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    private static void Print(IReadOnlyList<TaskItem> items)
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Список пуст.");
            return;
        }

        foreach (TaskItem item in items)
        {
            Console.WriteLine($"  #{item.Id} [{(item.IsDone ? "x" : " ")}] {item.Title}");
        }
    }
}
