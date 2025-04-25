using Nuta.BuildingBlocks.Domain;

namespace Nuta.Products.Domain.Aggregates.Additive;

public class AdditiveId(Guid value) : TypedIdValueBase(value);