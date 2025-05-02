namespace Nuta.Backend.BuildingBlocks.Domain;

public class DomainEventBase : IDomainEvent
{
    public Guid Id { get; } = Guid.CreateVersion7();

    public DateTime OccurredAt { get; } = DateTime.UtcNow;
}