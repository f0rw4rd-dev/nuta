using Nuta.BuildingBlocks.Domain;

namespace Nuta.Users.Domain.Aggregates.Product;

public class ProductId(Guid value) : TypedIdValueBase(value);