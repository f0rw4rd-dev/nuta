using Nuta.Backend.BuildingBlocks.Domain;
using Nuta.Backend.Products.Domain.Aggregates.Product;
using Nuta.Backend.Products.Domain.Aggregates.User;

namespace Nuta.Backend.Products.Domain.Aggregates.ProductProposal;

public class ProductProposal : Entity, IAggregateRoot
{
    public ProductProposalId Id { get; private set; }
    
    public ProductId? ProductId { get; private set; }
    
    public UserId UserId { get; private set; }
    
    public string Name { get; private set; }
    
    public string Details { get; private set; }
    
    public bool IsApproved { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    private ProductProposal()
    {
    }
}