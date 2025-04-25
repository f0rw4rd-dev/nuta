using Nuta.BuildingBlocks.Domain;
using Nuta.Users.Domain.Aggregates.User.ValueObjects;
using Nuta.Users.Domain.Aggregates.Product;

namespace Nuta.Users.Domain.Aggregates.User;

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