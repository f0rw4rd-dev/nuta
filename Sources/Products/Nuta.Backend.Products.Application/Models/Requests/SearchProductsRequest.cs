using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.BuildingBlocks.Application.Structs;
using Nuta.Backend.Products.Application.Enums;

namespace Nuta.Backend.Products.Application.Models.Requests;

public record SearchProductsRequest(
    Optional<string> Term,
    Optional<ProductSortBy> SortBy,
    Optional<ProductFilter> Filter,
    Pagination Pagination);