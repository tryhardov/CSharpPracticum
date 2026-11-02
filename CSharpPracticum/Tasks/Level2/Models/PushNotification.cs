namespace CSharpPracticum.Tasks.Level2;

public sealed class PushNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"[Push] {message}");
}
