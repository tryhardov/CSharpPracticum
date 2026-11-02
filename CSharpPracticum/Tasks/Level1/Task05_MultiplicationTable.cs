using System.Text;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(5, "вложенные for, форматирование {value,4}, StringBuilder")]
public sealed class Task05_MultiplicationTable : ITask
{
    public string Title => "Таблица умножения 10×10";

    public string Description => "Вывести таблицу умножения 10×10 с выровненными столбцами.";

    public string[] Requirements =>
    [
        "Вложенные циклы for",
        "Выровнять столбцы",
        "Заголовки строк и столбцов (приветствуются)",
    ];

    public void Run()
    {
        const int size = 10;

        var header = new StringBuilder("     |");
        for (int j = 1; j <= size; j++)
        {
            header.Append($"{j,4}");
        }

        Console.WriteLine(header);
        Console.WriteLine(new string('-', header.Length));

        for (int i = 1; i <= size; i++)
        {
            var row = new StringBuilder($"{i,4} |");
            for (int j = 1; j <= size; j++)
            {
                row.Append($"{i * j,4}");
            }

            Console.WriteLine(row);
        }
    }
}
