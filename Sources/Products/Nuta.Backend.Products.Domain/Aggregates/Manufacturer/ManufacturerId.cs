using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Products.Domain.Aggregates.Manufacturer;

public class ManufacturerId(Guid value) : TypedIdValueBase(value);