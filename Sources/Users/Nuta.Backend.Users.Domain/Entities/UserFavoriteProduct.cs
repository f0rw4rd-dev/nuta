using System.Diagnostics.CodeAnalysis;
using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Users.Domain.Entities;

public class UserFavoriteProduct : Entity
{
    public Guid UserId { get; }

    public Guid ProductId { get; }
    
    public DateTime LikedAt { get; }

    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private UserFavoriteProduct()
    {
        // EF Core
    }

    private UserFavoriteProduct(Guid userId, Guid productId)
    {
        UserId = userId;
        ProductId = productId;
        LikedAt = DateTime.UtcNow;
    }

    public static UserFavoriteProduct Create(Guid userId, Guid productId)
    {
        return new UserFavoriteProduct(userId, productId);
    }
}