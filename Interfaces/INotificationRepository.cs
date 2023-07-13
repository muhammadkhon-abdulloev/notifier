using notifier;

namespace NotifierApp.Interfaces;

public interface INotificationRepository
{
    public IEnumerable<Notification> GetAll();
    public void Add(Notification notification);
    public Notification? Get();
}