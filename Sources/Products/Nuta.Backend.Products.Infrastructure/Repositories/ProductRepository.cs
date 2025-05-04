using Microsoft.EntityFrameworkCore;
using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Products.Domain.Aggregates;
using Nuta.Backend.Products.Domain.Repositories;
using Nuta.Backend.Products.Infrastructure.Postgres;

namespace Nuta.Backend.Products.Infrastructure.Repositories;

public class ProductRepository(ProductsModuleDbContext dbContext) : IProductRepository
{
    public ValueTask<Product?> GetByIdAsync(Guid productId, CancellationToken cancellationToken)
    {
        return dbContext.Products.FindAsync(keyValues: [productId], cancellationToken);
    }

    public Task<Product?> GetByEan13Async(string ean13, CancellationToken cancellationToken)
    {
        return dbContext.Products
            .TagWith($"{nameof(ProductRepository)} - {nameof(GetByEan13Async)}")
            .Where(product => product.Ean13 == ean13)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Product>> GetListAsync(Pagination pagination,
        CancellationToken cancellationToken)
    {
        return await dbContext.Products
            .TagWith($"{nameof(ProductRepository)} - {nameof(GetListAsync)}")
            .OrderBy(x => x.CreatedAt)
            .Skip(pagination.Offset)
            .Take(pagination.Limit)
            .ToArrayAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Product>> GetListByIdsAsync(
        IReadOnlyCollection<Guid> productIds,
        Pagination pagination,
        CancellationToken cancellationToken)
    {
        return await dbContext.Products
            .TagWith($"{nameof(ProductRepository)} - {nameof(GetListByIdsAsync)}")
            .Where(product => productIds.Contains(product.Id))
            .OrderBy(x => x.CreatedAt)
            .Skip(pagination.Offset)
            .Take(pagination.Limit)
            .ToArrayAsync(cancellationToken);
    }

    public void Add(Product product)
    {
        dbContext.Products.Add(product);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}