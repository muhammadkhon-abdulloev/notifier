using notifier;
using NotifierApp.Interfaces;

namespace NotifierApp.Repository;

public class NotificationRepository : INotificationRepository
{
    private Queue<Notification> NotificationsQueue { get; }

    public NotificationRepository()
    {
        NotificationsQueue = new Queue<Notification>();
    }
    
    public void Add(Notification notification) => NotificationsQueue.Enqueue(notification);
    public IEnumerable<Notification> GetAll() => NotificationsQueue.ToArray();
    public Notification? Get() => NotificationsQueue.TryDequeue(out var notification) ? notification : null;


}