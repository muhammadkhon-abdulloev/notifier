using Microsoft.AspNetCore.Mvc;
using notifier.Service;

namespace notifier.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesResponseType(StatusCodes.Status201Created)]
public class NotificationController: ControllerBase
{
    private readonly ILogger<NotificationController> _logger;

    public NotificationController(ILogger<NotificationController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public IEnumerable<Notification> GetAll()
    {
        
        return NotificationService.GetAll();
    }
    
    [HttpPost]
    public IActionResult Create(Notification notification)
    {
        NotificationService.Add(notification);
        NotificationService.Notify(notification);
        
        return CreatedAtAction(nameof(GetAll), new {Ok= true});
    }
}