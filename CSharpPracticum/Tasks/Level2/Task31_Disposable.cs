namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(31, "IDisposable, using-блок, using var, StreamWriter, Path.GetTempFileName")]
public sealed class Task31_Disposable : ITask
{
    public string Title => "IDisposable + using";

    public string Description => "Класс FileWriter закрывает файл через Dispose().";

    public string[] Requirements =>
    [
        "FileWriter с полем StreamWriter и Dispose()",
        "Использование через using-блок",
        "Дополнительно: using var (C# 8+)",
    ];

    public void Run()
    {
        string path = Path.GetTempFileName();
        try
        {
            FileWriter outer;
            using (outer = new FileWriter(path))
            {
                outer.WriteLine("первая строка (using-блок)");
            }

            Console.WriteLine($"После using-блока IsDisposed = {outer.IsDisposed}");
            outer.Dispose();
            Console.WriteLine("Повторный Dispose() не падает.");

            using var second = new FileWriter(path, append: true);
            second.WriteLine("вторая строка (using var)");
            second.Dispose();

            try
            {
                second.WriteLine("запись в закрытый файл");
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("Запись в закрытый FileWriter → ObjectDisposedException (ожидаемо).");
            }

            Console.WriteLine("Содержимое файла:");
            Console.Write(File.ReadAllText(path));
        }
        finally
        {
            File.Delete(path);
        }
    }
}
