using Nuta.BuildingBlocks.Domain;
using Nuta.Users.Domain.Aggregates.User.ValueObjects;
using Nuta.Users.Domain.Aggregates.Product;

namespace Nuta.Users.Domain.Aggregates.User.Rules;

public class UserCannotRemoveNonFavoriteProductRule : IBusinessRule
{
    private IReadOnlyCollection<UserFavoriteProduct> FavoriteProducts { get; }
    
    private ProductId ProductId { get; }
    
    public UserCannotRemoveNonFavoriteProductRule(
        IReadOnlyCollection<UserFavoriteProduct> favoriteProducts, 
        ProductId productId)
    {
        FavoriteProducts = favoriteProducts;
        ProductId = productId;
    }
    
    public bool IsBroken()
    {
        return FavoriteProducts.All(p => p.ProductId != ProductId);
    }

    public string Message => "Пользователь не может удалить товар из избранного, если он не был ранее добавлен";
}