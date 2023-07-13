namespace notifier;

public class Notification
{
    public required string OrderType { get; set; }

    public required string SessionID { get; set; }
    
    public required string Card { get; set; }

    public required string EventDate { get; set; }
    
    public required string WebsiteUrl { get; set; }
}