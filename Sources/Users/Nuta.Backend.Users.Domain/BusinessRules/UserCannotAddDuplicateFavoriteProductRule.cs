using Nuta.Backend.BuildingBlocks.Domain;
using Nuta.Backend.Users.Domain.Entities;

namespace Nuta.Backend.Users.Domain.BusinessRules;

public class UserCannotAddDuplicateFavoriteProductRule(
    IReadOnlyCollection<UserFavoriteProduct> favoriteProducts,
    Guid productId)
    : IBusinessRule
{
    public bool IsBroken()
    {
        return favoriteProducts.Any(userFavoriteProduct => userFavoriteProduct.ProductId == productId);
    }

    public string Message => "Пользователь не может добавить один и тот же товар в избранное несколько раз";
}