namespace Nuta.Backend.BuildingBlocks.Infrastructure.Inbox;

public class InboxMessage
{
    public Guid Id { get; }

    public string Type { get; }

    public string Payload { get; }
    
    public InboxMessageStatus Status { get; }
    
    public int RetryCount { get; private set; }

    public DateTime ReceivedAt { get; }

    private InboxMessage()
    {
    }

    public InboxMessage(string type, string payload)
    {
        Id = Guid.CreateVersion7();
        Type = type;
        Payload = payload;
        RetryCount = 0;
        ReceivedAt = DateTime.UtcNow;
    }
    
    public void MarkAsProcessed()
    {
    }
    
    public void IncrementRetryCount()
    {
        RetryCount++;
    }
}