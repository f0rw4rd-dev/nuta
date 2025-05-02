using Nuta.Backend.BuildingBlocks.Domain;
using Nuta.Backend.Products.Domain.Entities;

namespace Nuta.Backend.Products.Domain.BusinessRules;

public class UserCannotLeaveMultipleReviewsForSameProductRule(
    IReadOnlyCollection<ProductUserReview> productUserReviews,
    Guid userId)
    : IBusinessRule
{
    public bool IsBroken()
    {
        return productUserReviews.Any(x => x.UserId == userId);
    }

    public string Message => "Пользователь не может оставить несколько отзывов на один и тот же продукт";
}