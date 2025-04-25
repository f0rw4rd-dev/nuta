using Nuta.BuildingBlocks.Domain;

namespace Nuta.Products.Domain.Aggregates.Manufacturer;

public class ManufacturerId(Guid value) : TypedIdValueBase(value);