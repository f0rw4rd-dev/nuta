using MediatR;
using Nuta.Backend.Products.Application.Dtos;

namespace Nuta.Backend.Products.Application.Queries.GetProductShortInfoList;

public record GetProductShortInfoListQuery(IReadOnlyCollection<Guid> ProductIds)
    : IRequest<IReadOnlyCollection<ProductShortInfoDto>>;