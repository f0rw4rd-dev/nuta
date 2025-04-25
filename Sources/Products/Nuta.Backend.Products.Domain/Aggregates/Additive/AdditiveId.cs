using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Products.Domain.Aggregates.Additive;

public class AdditiveId(Guid value) : TypedIdValueBase(value);