using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Users.Domain.Aggregates.Product;

public class ProductId(Guid value) : TypedIdValueBase(value);