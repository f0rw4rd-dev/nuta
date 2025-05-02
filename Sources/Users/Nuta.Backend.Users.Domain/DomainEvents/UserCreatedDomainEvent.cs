using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Users.Domain.DomainEvents;

public class UserCreatedDomainEvent(Guid userId) : DomainEventBase
{
    public Guid UserId { get; } = userId;
}