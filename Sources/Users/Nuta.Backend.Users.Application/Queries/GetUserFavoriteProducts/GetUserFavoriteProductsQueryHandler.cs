using MediatR;
using Nuta.Backend.Users.Application.Dtos;
using Nuta.Backend.Users.Domain.Exceptions;
using Nuta.Backend.Users.Domain.Repositories;

namespace Nuta.Backend.Users.Application.Queries.GetUserFavoriteProducts;

public class GetUserFavoriteProductsQueryHandler(IUserRepository userRepository)
    : IRequestHandler<GetUserFavoriteProductsQuery, IReadOnlyCollection<UserFavoriteProductDto>>
{
    public async Task<IReadOnlyCollection<UserFavoriteProductDto>> Handle(
        GetUserFavoriteProductsQuery request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
            throw new UserNotFoundException(request.UserId);

        return user.FavoriteProducts
            .OrderByDescending(x => x.LikedAt)
            .Skip(request.Pagination.Offset)
            .Take(request.Pagination.Limit)
            .Select(x => new UserFavoriteProductDto(x.ProductId))
            .ToArray();
    }
}