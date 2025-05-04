using Microsoft.EntityFrameworkCore;
using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.BuildingBlocks.Application.Structs;
using Nuta.Backend.Products.Application.Enums;
using Nuta.Backend.Products.Application.Models;
using Nuta.Backend.Products.Application.Services.Interfaces;
using Nuta.Backend.Products.Domain.Aggregates;
using Nuta.Backend.Products.Infrastructure.Postgres;

namespace Nuta.Backend.Products.Infrastructure.Services;

public class ProductSearchService(ProductsModuleDbContext dbContext) : IProductSearchService
{
    public async Task<IReadOnlyCollection<Product>> SearchAsync(
        Optional<string> term,
        Optional<ProductSortBy> sortBy,
        Optional<ProductFilter> filter,
        Pagination pagination,
        CancellationToken cancellationToken)
    {
        var query = dbContext.Products
            .TagWith($"{nameof(ProductSearchService)} - {nameof(SearchAsync)}")
            .AsQueryable();

        if (term.HasValue && !string.IsNullOrWhiteSpace(term.Value))
        {
            term.Value = term.Value.Trim().ToLower();
            query = query.Where(product =>
                product.Name.ToLower().Contains(term.Value) ||
                (product.Description != null && product.Description.ToLower().Contains(term.Value)));
        }

        if (filter.HasValue)
        {
            if (filter.Value.Category.HasValue)
            {
                var category = filter.Value.Category.Value;
                query = query.Where(product => product.Category == category);
            }

            if (filter.Value.SubCategory.HasValue)
            {
                var subCategory = filter.Value.SubCategory.Value;
                query = query.Where(product => product.SubCategory == subCategory);
            }
        }

        if (sortBy.HasValue)
        {
            query = sortBy.Value switch
            {
                ProductSortBy.UserScoreAsc => query.OrderBy(product => product.UserScore),
                ProductSortBy.UserScoreDesc => query.OrderByDescending(product => product.UserScore),
                // ProductSortBy.NutaScoreAsc => query.OrderBy(product => product.NutaScore),
                // ProductSortBy.NutaScoreDesc => query.OrderByDescending(product => product.NutaScore),
                _ => query.OrderByDescending(product => product.Id)
            };
        }
        else
        {
            query = query.OrderByDescending(p => p.Id);
        }

        var result = await query
            .Skip(pagination.Offset)
            .Take(pagination.Limit)
            .ToArrayAsync(cancellationToken);

        return result;
    }
}