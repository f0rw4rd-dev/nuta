using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Products.Domain.Aggregates.ProductProposal;

public class ProductProposalId(Guid value) : TypedIdValueBase(value);