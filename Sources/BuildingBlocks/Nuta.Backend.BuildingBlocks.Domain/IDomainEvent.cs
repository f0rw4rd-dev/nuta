using MediatR;

namespace Nuta.Backend.BuildingBlocks.Domain;

public interface IDomainEvent : INotification
{
    Guid EventId { get; }

    DateTime OccurredAt { get; }
}