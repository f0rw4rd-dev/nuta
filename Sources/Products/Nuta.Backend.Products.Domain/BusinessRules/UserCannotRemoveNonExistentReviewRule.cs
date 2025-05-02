using Nuta.Backend.BuildingBlocks.Domain;
using Nuta.Backend.Products.Domain.Entities;

namespace Nuta.Backend.Products.Domain.BusinessRules;

public class UserCannotRemoveNonExistentReviewRule(
    IReadOnlyCollection<ProductUserReview> productUserReviews,
    Guid userId)
    : IBusinessRule
{
    public bool IsBroken()
    {
        return productUserReviews.All(x => x.UserId != userId);
    }

    public string Message => "Пользователь не может удалить несуществующий отзыв";
}