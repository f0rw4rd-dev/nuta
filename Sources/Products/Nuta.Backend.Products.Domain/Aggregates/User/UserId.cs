using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Products.Domain.Aggregates.User;

public class UserId(Guid value) : TypedIdValueBase(value);