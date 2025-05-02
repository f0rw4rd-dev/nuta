using System.Diagnostics.CodeAnalysis;
using Nuta.Backend.BuildingBlocks.Domain;
using Nuta.Backend.Products.Domain.Enums;

namespace Nuta.Backend.Products.Domain.Aggregates;

public class ProductProposal : Entity, IAggregateRoot
{
    public Guid Id { get; }
    
    public Guid? ProductId { get; }
    
    public Guid UserId { get; }
    
    public string Name { get; private set; } = null!;

    public string Details { get; private set; } = null!;

    public ProductProposalStatus Status { get; private set; }
    
    public DateTime CreatedAt { get; }
    
    public DateTime UpdatedAt { get; private set; }
    
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private ProductProposal()
    {
        // EF Core
    }
    
    private ProductProposal(Guid id, Guid? productId, Guid userId, string name, string details)
    {
        Id = id;
        ProductId = productId;
        UserId = userId;
        Name = name.Trim();
        Details = details.Trim();
        Status = ProductProposalStatus.New;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }
    
    public static ProductProposal Create(Guid? productId, Guid userId, string name, string details)
    {
        return new ProductProposal(id: Guid.CreateVersion7(), productId, userId, name, details);
    }
    
    public void Approve()
    {
        Status = ProductProposalStatus.Approved;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Reject()
    {
        Status = ProductProposalStatus.Rejected;
        UpdatedAt = DateTime.UtcNow;
    }
}