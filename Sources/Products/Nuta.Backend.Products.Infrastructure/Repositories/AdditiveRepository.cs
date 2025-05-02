using Microsoft.EntityFrameworkCore;
using Nuta.Backend.Products.Domain.Aggregates;
using Nuta.Backend.Products.Domain.Repositories;
using Nuta.Backend.Products.Infrastructure.Postgres;

namespace Nuta.Backend.Products.Infrastructure.Repositories;

public class AdditiveRepository(ProductsModuleDbContext dbContext) : IAdditiveRepository
{
    public async Task<IReadOnlyCollection<Additive>> GetListAsync(
        IReadOnlyCollection<Guid> additiveIds,
        CancellationToken cancellationToken)
    {
        return await dbContext.Additives.Where(x => additiveIds.Contains(x.Id)).ToListAsync(cancellationToken);
    }
}