using MediatR;
using Nuta.Backend.Users.Application.Dtos;
using Nuta.Backend.Users.Domain.Repositories;

namespace Nuta.Backend.Users.Application.Queries.GetUserViewedProductList;

public class GetUserViewedProductListQueryHandler(IUserRepository userRepository)
    : IRequestHandler<GetUserViewedProductListQuery, IReadOnlyCollection<UserProductViewDto>>
{
    public async Task<IReadOnlyCollection<UserProductViewDto>> Handle(
        GetUserViewedProductListQuery request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(request.UserId, cancellationToken);

        if (user is null)
            throw new ArgumentException($"Пользователь не найден. UserId = {request.UserId}");

        return user.ViewedProducts
            .Select(x => new UserProductViewDto(x.ProductId, x.ViewedAt))
            .ToArray();
    }
}