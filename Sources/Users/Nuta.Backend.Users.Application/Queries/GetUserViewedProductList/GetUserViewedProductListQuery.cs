using MediatR;
using Nuta.Backend.Users.Application.Dtos;

namespace Nuta.Backend.Users.Application.Queries.GetUserViewedProductList;

public record GetUserViewedProductListQuery(Guid UserId) : IRequest<IReadOnlyCollection<UserProductViewDto>>;