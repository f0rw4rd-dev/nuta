using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.BuildingBlocks.Application.Structs;
using Nuta.Backend.Products.Application.Enums;
using Nuta.Backend.Products.Application.Models;
using Nuta.Backend.Products.Domain.Aggregates;

namespace Nuta.Backend.Products.Application.Services.Interfaces;

public interface IProductSearchService
{
    Task<IReadOnlyCollection<Product>> SearchAsync(
        Optional<string> term,
        Optional<ProductSortBy> sortBy,
        Optional<ProductFilter> filter,
        Pagination pagination,
        CancellationToken cancellationToken);
}