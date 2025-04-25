using Nuta.BuildingBlocks.Domain;
using Nuta.Users.Domain.Aggregates.User.ValueObjects;
using Nuta.Users.Domain.Aggregates.Product;

namespace Nuta.Users.Domain.Aggregates.User;

public class UserProductView : Entity
{
    public UserId UserId { get; }
    
    public ProductId ProductId { get; }
    
    public DateTime ViewedAt { get; }
    
    private UserProductView()
    {
    }
    
    private UserProductView(UserId userId, ProductId productId)
    {
        UserId = userId;
        ProductId = productId;
        ViewedAt = DateTime.UtcNow;
    }
    
    public static UserProductView Create(UserId userId, ProductId productId)
    {
        return new UserProductView(userId, productId);
    }
}