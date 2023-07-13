using NotifierApp.Interfaces;

namespace notifier.Service;

public class NotificationService
{
    private readonly INotificationRepository _notificationRepository;
    public IEnumerable<Notification> GetAll() => _notificationRepository.GetAll();
    public void Add(Notification notification) => _notificationRepository.Add(notification);
    public Notification? Get() => _notificationRepository.Get();

    public NotificationService(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }
    
    public static void Notify(Notification notification)
    {
        Console.WriteLine($"Notification. Session ID: {notification.SessionID}\n" +
                          $"Operation: {notification.OrderType} {notification.WebsiteUrl}\n" +
                          $"Card: {notification.Card}\n" +
                          $"Time: {notification.EventDate}");
    }
}