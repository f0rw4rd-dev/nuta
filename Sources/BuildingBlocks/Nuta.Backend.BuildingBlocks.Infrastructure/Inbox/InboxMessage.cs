using System.Diagnostics.CodeAnalysis;

namespace Nuta.Backend.BuildingBlocks.Infrastructure.Inbox;

public class InboxMessage
{
    public Guid Id { get; }

    public string Type { get; } = null!;

    public string Payload { get; } = null!;

    public InboxMessageStatus Status { get; private set; }
    
    public int RetryCount { get; private set; }

    public DateTime ReceivedAt { get; }

    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private InboxMessage()
    {
        // EF Core
    }

    public InboxMessage(string type, string payload)
    {
        Id = Guid.CreateVersion7();
        Type = type;
        Payload = payload;
        RetryCount = 0;
        ReceivedAt = DateTime.UtcNow;
    }
    
    public void MarkAsCompleted()
    {
        Status = InboxMessageStatus.Completed;
    }
    
    public void IncrementRetryCount()
    {
        RetryCount++;
    }
}