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
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(5000, stoppingToken);

            if (_notificationService.Get(out var notification) && notification != null)
            {
                NotificationService.Notify(notification);
            }
        }
    }
}