using System.Diagnostics.CodeAnalysis;
using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Users.Domain.Entities;

public class UserViewedProduct : Entity
{
    public Guid UserId { get; }
    
    public Guid ProductId { get; }
    
    public DateTime ViewedAt { get; private set; }
    
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private UserViewedProduct()
    {
        // EF Core
    }
    
    private UserViewedProduct(Guid userId, Guid productId)
    {
        UserId = userId;
        ProductId = productId;
        ViewedAt = DateTime.UtcNow;
    }
    
    public static UserViewedProduct Create(Guid userId, Guid productId)
    {
        return new UserViewedProduct(userId, productId);
    }
    
    public void UpdateViewedAt()
    {
        ViewedAt = DateTime.UtcNow;
    }
}