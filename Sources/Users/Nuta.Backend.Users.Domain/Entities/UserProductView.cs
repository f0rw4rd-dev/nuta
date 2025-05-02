using System.Diagnostics.CodeAnalysis;
using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Users.Domain.Entities;

public class UserProductView : Entity
{
    public Guid UserId { get; }
    
    public Guid ProductId { get; }
    
    public DateTime ViewedAt { get; }
    
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private UserProductView()
    {
        // EF Core
    }
    
    private UserProductView(Guid userId, Guid productId)
    {
        UserId = userId;
        ProductId = productId;
        ViewedAt = DateTime.UtcNow;
    }
    
    public static UserProductView Create(Guid userId, Guid productId)
    {
        return new UserProductView(userId, productId);
    }
}