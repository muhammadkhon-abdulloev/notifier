namespace notifier.Service;

public class NotificationService
{
    private static List<Notification> Notifications { get; } = new();
    
    public static IEnumerable<Notification> GetAll() => Notifications;
    public static void Add(Notification notification) => Notifications.Add(notification);

    public static void Notify(Notification notification)
    {
        Console.WriteLine($"Notification. Session ID: {notification.SessionID}\n" +
                          $"Operation: {notification.OrderType} {notification.WebsiteUrl}\n" +
                          $"Card: {notification.Card}\n" +
                          $"Time: {notification.EventDate}");
    }
}