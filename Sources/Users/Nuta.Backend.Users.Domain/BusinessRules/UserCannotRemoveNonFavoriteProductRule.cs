using Nuta.Backend.BuildingBlocks.Domain;
using Nuta.Backend.Users.Domain.Entities;

namespace Nuta.Backend.Users.Domain.BusinessRules;

public class UserCannotRemoveNonFavoriteProductRule(
    IReadOnlyCollection<UserFavoriteProduct> favoriteProducts,
    Guid productId)
    : IBusinessRule
{
    public bool IsBroken()
    {
        return favoriteProducts.All(userFavoriteProduct => userFavoriteProduct.ProductId != productId);
    }

    public string Message => "Пользователь не может удалить товар из избранного, если он не был ранее добавлен";
}