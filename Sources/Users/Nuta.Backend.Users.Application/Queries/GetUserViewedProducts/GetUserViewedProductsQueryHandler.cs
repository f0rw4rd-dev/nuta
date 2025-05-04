using MediatR;
using Nuta.Backend.Users.Application.Dtos;
using Nuta.Backend.Users.Domain.Exceptions;
using Nuta.Backend.Users.Domain.Repositories;

namespace Nuta.Backend.Users.Application.Queries.GetUserViewedProducts;

public class GetUserViewedProductsQueryHandler(IUserRepository userRepository)
    : IRequestHandler<GetUserViewedProductsQuery, IReadOnlyCollection<UserViewedProductDto>>
{
    public async Task<IReadOnlyCollection<UserViewedProductDto>> Handle(
        GetUserViewedProductsQuery request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(request.UserId, cancellationToken);
        
        if (user is null)
            throw new UserNotFoundException(request.UserId);
        
        return user.ViewedProducts
            .OrderByDescending(x => x.ViewedAt)
            .Skip(request.Pagination.Offset)
            .Take(request.Pagination.Limit)
            .Select(x => new UserViewedProductDto(x.ProductId, x.ViewedAt))
            .ToArray();
    }
}