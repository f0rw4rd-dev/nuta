using Nuta.BuildingBlocks.Domain;

namespace Nuta.BuildingBlocks.Application.Events;

public class DomainNotificationBase<T>(T domainEvent, Guid id) : IDomainEventNotification<T> where T : IDomainEvent
{
    public T DomainEvent { get; } = domainEvent;

    public Guid Id { get; } = id;
}