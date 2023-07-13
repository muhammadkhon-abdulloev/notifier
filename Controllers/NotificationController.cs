using Microsoft.AspNetCore.Mvc;
using notifier.Service;

namespace notifier.Controllers;

[ApiController]
[Route("notification")]
[ProducesResponseType(StatusCodes.Status201Created)]
public class NotificationController: ControllerBase
{
    private readonly ILogger<NotificationController> _logger;
    private readonly NotificationService _notificationService;
    public NotificationController(
        NotificationService notificationService, 
        ILogger<NotificationController> logger)
    {
        _notificationService = notificationService;
        _logger = logger;
    }
    [HttpGet]
    public IEnumerable<Notification> GetAll()
    {
        
        return _notificationService.GetAll();
    }
    
    [HttpPost]
    public IActionResult Create(Notification notification)
    {
        _notificationService.Add(notification);
        return CreatedAtAction(nameof(GetAll), new {Ok= true});
    }
}