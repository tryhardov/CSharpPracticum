namespace CSharpPracticum.Tasks.Level2;

public static class NotificationFactory
{
    public static INotification Create(NotificationType type) => type switch
    {
        NotificationType.Email => new EmailNotification(),
        NotificationType.Sms => new SmsNotification(),
        NotificationType.Push => new PushNotification(),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Неизвестный тип уведомления."),
    };
}
