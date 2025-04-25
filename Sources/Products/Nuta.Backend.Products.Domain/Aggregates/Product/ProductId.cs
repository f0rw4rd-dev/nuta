using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Products.Domain.Aggregates.Product;

public class ProductId(Guid value) : TypedIdValueBase(value);