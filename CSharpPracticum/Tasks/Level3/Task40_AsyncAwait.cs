namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(40, "async Task<string>, await, Task.Delay, try/catch, ArgumentException")]
public sealed class Task40_AsyncAwait : ITask
{
    public string Title => "async/await + исключения";

    public string Description => "Эмуляция скачивания с ошибкой при пустом URL.";

    public string[] Requirements =>
    [
        "async Task<string> DownloadAsync(string url) с Task.Delay(1000)",
        "Пустой url — ArgumentException",
        "Вызов через await внутри try/catch",
        "Показать успешный и ошибочный вызов",
    ];

    public static async Task<string> DownloadAsync(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentException("URL не может быть пустым.", nameof(url));
        }

        await Task.Delay(1000);
        return $"<html>содержимое {url}</html>";
    }

    /// <inheritdoc />
    public void Run() => RunAsync().GetAwaiter().GetResult();

    private static async Task RunAsync()
    {
        foreach (string url in new[] { "https://example.com", string.Empty })
        {
            try
            {
                Console.WriteLine($"Скачиваю «{url}»...");
                string content = await DownloadAsync(url);
                Console.WriteLine($"Готово: {content}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
