using notifier;
using notifier.Service;

namespace NotifierApp;

public class Worker: BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly NotificationService _notificationService;
    
    public Worker(NotificationService notificationService, ILogger<Worker> logger)
    {
        _notificationService = notificationService;
        _logger = logger;
    }
 
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {Time}", DateTimeOffset.Now);
            await Task.Delay(5000, stoppingToken);
            
            var notification = _notificationService.Get();
            if (notification is not null)
            {
                NotificationService.Notify(notification);
            }
        }
    }
}