using MediatR;

namespace Nuta.Backend.BuildingBlocks.Domain;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccurredAt { get; }
}