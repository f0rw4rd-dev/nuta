using Nuta.Backend.BuildingBlocks.Domain;
using Nuta.Backend.Users.Domain.Aggregates.Product;
using Nuta.Backend.Users.Domain.Aggregates.User.ValueObjects;

namespace Nuta.Backend.Users.Domain.Aggregates.User.Rules;

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