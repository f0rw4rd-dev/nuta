using Nuta.BuildingBlocks.Domain;
using Nuta.Products.Domain.Aggregates.User;

namespace Nuta.Products.Domain.Aggregates.Product;

public class ProductReview : Entity
{
    public ProductId ProductId { get; }
    
    public UserId UserId { get; }
    
    public int Rating { get; }
    
    public string Comment { get; }
    
    public bool IsHidden { get; private set; }
    
    public DateTime CreatedAt { get; }
    
    public DateTime UpdatedAt { get; private set; }
    
    private ProductReview()
    {
    }
}