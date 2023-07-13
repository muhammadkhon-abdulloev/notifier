namespace notifier.Service;

public class NotificationService
{
    private Queue<Notification> NotificationsQueue { get; }
    public IEnumerable<Notification> GetAll() => NotificationsQueue.ToArray();
    public void Add(Notification notification) => NotificationsQueue.Enqueue(notification);
    public bool Get(out Notification? notification) => NotificationsQueue.TryDequeue(out notification);
    
    public NotificationService()
    {
        NotificationsQueue = new Queue<Notification>();
    }
    
    public static void Notify(Notification notification)
    {
        Console.WriteLine($"Notification. Session ID: {notification.SessionID}\n" +
                          $"Operation: {notification.OrderType} {notification.WebsiteUrl}\n" +
                          $"Card: {notification.Card}\n" +
                          $"Time: {notification.EventDate}");
    }
}