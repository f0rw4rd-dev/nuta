using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Users.Domain.Aggregates.User;

public class UserId(Guid value) : TypedIdValueBase(value);