using MediatR;

namespace Nuta.BuildingBlocks.Domain;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccurredAt { get; }
}