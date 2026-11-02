namespace CSharpPracticum.Tasks.Level2;

public sealed class EmailNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"[Email] {message}");
}
