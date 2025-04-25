using MediatR;

namespace Nuta.BuildingBlocks.Infrastructure.EventBus;

public abstract class IntegrationEvent : INotification
{
    public Guid Id { get; }

    public DateTime OccurredAt { get; }

    protected IntegrationEvent(Guid id, DateTime occurredAt)
    {
        Id = id;
        OccurredAt = occurredAt;
    }
}