namespace Nuta.BuildingBlocks.Domain;

public class DomainEventBase : IDomainEvent
{
    public Guid Id { get; } = Guid.NewGuid();

    public DateTime OccurredAt { get; } = DateTime.UtcNow;
}