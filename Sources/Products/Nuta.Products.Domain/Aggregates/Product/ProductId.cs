using Nuta.BuildingBlocks.Domain;

namespace Nuta.Products.Domain.Aggregates.Product;

public class ProductId(Guid value) : TypedIdValueBase(value);