using MediatR;
using Nuta.Backend.Products.Application.Dtos;

namespace Nuta.Backend.Products.Application.Queries.GetProductsShortInfo;

public record GetProductsShortInfoQuery(IReadOnlyCollection<Guid> ProductIds)
    : IRequest<IReadOnlyCollection<ProductShortInfoDto>>;