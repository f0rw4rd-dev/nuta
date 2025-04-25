using Nuta.BuildingBlocks.Domain;

namespace Nuta.Products.Domain.Aggregates.User;

public class UserId(Guid value) : TypedIdValueBase(value);