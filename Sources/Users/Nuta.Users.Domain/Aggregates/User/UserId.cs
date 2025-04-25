using Nuta.BuildingBlocks.Domain;

namespace Nuta.Users.Domain.Aggregates.User;

public class UserId(Guid value) : TypedIdValueBase(value);