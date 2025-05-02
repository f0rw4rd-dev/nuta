using Microsoft.EntityFrameworkCore;
using Nuta.Backend.Products.Domain.Aggregates;
using Nuta.Backend.Products.Domain.Repositories;
using Nuta.Backend.Products.Infrastructure.Postgres;

namespace Nuta.Backend.Products.Infrastructure.Repositories;

public class ProductRepository(ProductsModuleDbContext dbContext) : IProductRepository
{
    public async Task<IReadOnlyCollection<Product>> GetListAsync(
        IReadOnlyCollection<Guid> productIds,
        CancellationToken cancellationToken)
    {
        return await dbContext.Products
            .TagWith($"{nameof(ProductRepository)} - {nameof(GetListAsync)}")
            .Where(x => productIds.Contains(x.Id))
            .ToArrayAsync(cancellationToken);
    }
}