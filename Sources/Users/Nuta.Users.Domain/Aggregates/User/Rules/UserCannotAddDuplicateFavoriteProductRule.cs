using Nuta.BuildingBlocks.Domain;
using Nuta.Users.Domain.Aggregates.User.ValueObjects;
using Nuta.Users.Domain.Aggregates.Product;

namespace Nuta.Users.Domain.Aggregates.User.Rules;

public class UserCannotAddDuplicateFavoriteProductRule : IBusinessRule
{
    private IReadOnlyCollection<UserFavoriteProduct> FavoriteProducts { get; }
    
    private ProductId ProductId { get; }
    
    public UserCannotAddDuplicateFavoriteProductRule(
        IReadOnlyCollection<UserFavoriteProduct> favoriteProducts, 
        ProductId productId)
    {
        FavoriteProducts = favoriteProducts;
        ProductId = productId;
    }
    
    public bool IsBroken()
    {
        return FavoriteProducts.Any(p => p.ProductId == ProductId);
    }

    public string Message => "Пользователь не может добавить один и тот же товар в избранное несколько раз";
}