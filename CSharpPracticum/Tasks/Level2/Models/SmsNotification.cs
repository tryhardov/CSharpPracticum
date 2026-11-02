namespace CSharpPracticum.Tasks.Level2;

public sealed class SmsNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"[SMS] {message}");
}
