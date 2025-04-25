using Nuta.Backend.BuildingBlocks.Domain;
using Nuta.Backend.Users.Domain.Aggregates.Product;
using Nuta.Backend.Users.Domain.Aggregates.User.ValueObjects;

namespace Nuta.Backend.Users.Domain.Aggregates.User;

public class UserFavoriteProduct : Entity
{
    public UserId UserId { get; }

    public ProductId ProductId { get; }

    private UserFavoriteProduct()
    {
    }

    private UserFavoriteProduct(UserId userId, ProductId productId)
    {
        UserId = userId;
        ProductId = productId;
    }

    public static UserFavoriteProduct Create(UserId userId, ProductId productId)
    {
        return new UserFavoriteProduct(userId, productId);
    }
}