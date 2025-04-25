using MediatR;

namespace Nuta.BuildingBlocks.Application.Events;

public interface IDomainEventNotification : INotification
{
    Guid Id { get; }
}

public interface IDomainEventNotification<out TEventType> : IDomainEventNotification
{
    TEventType DomainEvent { get; }
}