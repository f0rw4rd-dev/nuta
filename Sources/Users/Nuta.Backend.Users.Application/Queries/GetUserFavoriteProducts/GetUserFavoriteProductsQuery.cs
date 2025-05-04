using MediatR;
using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Users.Application.Dtos;

namespace Nuta.Backend.Users.Application.Queries.GetUserFavoriteProducts;

public record GetUserFavoriteProductsQuery(Guid UserId, Pagination Pagination)
    : IRequest<IReadOnlyCollection<UserFavoriteProductDto>>;