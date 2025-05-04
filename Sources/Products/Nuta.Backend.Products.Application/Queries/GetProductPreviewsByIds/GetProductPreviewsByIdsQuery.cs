using MediatR;
using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Products.Application.Dtos;

namespace Nuta.Backend.Products.Application.Queries.GetProductPreviewsByIds;

public record GetProductPreviewsByIdsQuery(
    IReadOnlyCollection<Guid> ProductIds,
    Pagination Pagination)
    : IRequest<IReadOnlyCollection<ProductPreviewDto>>;