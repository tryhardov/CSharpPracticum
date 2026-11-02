namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(42, "CancellationTokenSource(.CancelAfter), CancellationToken, OperationCanceledException")]
public sealed class Task42_Cancellation : ITask
{
    public string Title => "CancellationToken: отмена через 2 сек";

    public string Description => "Долгая операция, которую отменяют через 2 секунды.";

    public string[] Requirements =>
    [
        "LongOperationAsync(CancellationToken): 10 раз Task.Delay(500, token)",
        "CancellationTokenSource, отмена через 2 секунды",
        "Обработать OperationCanceledException и вывести «операция отменена»",
    ];

    public static async Task LongOperationAsync(CancellationToken token)
    {
        for (int step = 1; step <= 10; step++)
        {
            await Task.Delay(500, token);
            Console.WriteLine($"  шаг {step}/10 выполнен");
        }
    }

    public void Run() => RunAsync().GetAwaiter().GetResult();

    private static async Task RunAsync()
    {
        using var cts = new CancellationTokenSource();
        cts.CancelAfter(TimeSpan.FromSeconds(2));

        try
        {
            await LongOperationAsync(cts.Token);
            Console.WriteLine("Операция завершена.");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("операция отменена");
        }
    }
}
