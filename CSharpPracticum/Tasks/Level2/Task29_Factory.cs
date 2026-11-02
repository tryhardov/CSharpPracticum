namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(29, "interface INotification, enum NotificationType, switch expression")]
public sealed class Task29_Factory : ITask
{
    public string Title => "Паттерн «Фабрика» (уведомления)";
    public string Description => "Фабрика создаёт уведомление по значению enum.";
    public string[] Requirements =>
    [
        "INotification.Send(string)",
        "EmailNotification, SmsNotification, PushNotification",
        "NotificationFactory.Create(NotificationType)",
    ];

    public void Run()
    {
        foreach (NotificationType type in Enum.GetValues<NotificationType>())
        {
            INotification notification = NotificationFactory.Create(type);
            Console.WriteLine($"{type} → {notification.GetType().Name}");
            notification.Send("Привет из фабрики!");
        }
    }
}
