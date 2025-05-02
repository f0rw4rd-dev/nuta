using System.Diagnostics.CodeAnalysis;

namespace Nuta.Backend.BuildingBlocks.Infrastructure.Outbox;

public class OutboxMessage
{
    public Guid Id { get; }
    
    public string Type { get; }
    
    public string Payload { get; }
    
    public bool IsSent { get; private set; }
    
    public DateTime OccurredAt { get; }
    
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private OutboxMessage()
    {
        // EF Core
    }

    public OutboxMessage(string type, string payload)
    {
        Id = Guid.CreateVersion7();
        Type = type;
        Payload = payload;
        IsSent = false;
        OccurredAt = DateTime.UtcNow;
    }
    
    public void MarkAsSent()
    {
        IsSent = true;
    }
}