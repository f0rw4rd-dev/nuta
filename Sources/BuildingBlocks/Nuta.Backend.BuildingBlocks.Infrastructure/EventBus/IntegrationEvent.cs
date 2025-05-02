using MediatR;

namespace Nuta.Backend.BuildingBlocks.Infrastructure.EventBus;

public abstract class IntegrationEvent(Guid id, DateTime occurredAt) : INotification
{
    public Guid Id { get; } = id;

    public DateTime OccurredAt { get; } = occurredAt;
}