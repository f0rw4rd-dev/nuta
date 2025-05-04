using MediatR;
using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Users.Application.Dtos;

namespace Nuta.Backend.Users.Application.Queries.GetUserViewedProducts;

public record GetUserViewedProductsQuery(Guid UserId, Pagination Pagination)
    : IRequest<IReadOnlyCollection<UserViewedProductDto>>;