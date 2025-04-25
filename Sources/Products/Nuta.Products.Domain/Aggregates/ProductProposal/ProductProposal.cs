using Nuta.BuildingBlocks.Domain;
using Nuta.Products.Domain.Aggregates.Product;
using Nuta.Products.Domain.Aggregates.User;

namespace Nuta.Products.Domain.Aggregates.ProductProposal;

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