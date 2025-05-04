using MediatR;
using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.BuildingBlocks.Application.Structs;
using Nuta.Backend.Products.Application.Dtos;
using Nuta.Backend.Products.Application.Enums;
using Nuta.Backend.Products.Application.Models;

namespace Nuta.Backend.Products.Application.Queries.SearchProducts;

public record SearchProductsQuery(
    Optional<string> Term,
    Optional<ProductSortBy> SortBy,
    Optional<ProductFilter> Filter,
    Pagination Pagination)
    : IRequest<IReadOnlyCollection<ProductPreviewDto>>;