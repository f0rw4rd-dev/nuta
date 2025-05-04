using Microsoft.EntityFrameworkCore;
using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Products.Domain.Aggregates;
using Nuta.Backend.Products.Domain.Repositories;
using Nuta.Backend.Products.Infrastructure.Postgres;

namespace Nuta.Backend.Products.Infrastructure.Repositories;

public class AdditiveRepository(ProductsModuleDbContext dbContext) : IAdditiveRepository
{
    public ValueTask<Additive?> GetByIdAsync(Guid additiveId, CancellationToken cancellationToken)
    {
        return dbContext.Additives.FindAsync([additiveId], cancellationToken);
    }

    public async Task<IReadOnlyCollection<Additive>> GetListAsync(
        Pagination pagination,
        CancellationToken cancellationToken)
    {
        return await dbContext.Additives
            .TagWith($"{nameof(AdditiveRepository)} - {nameof(GetListByIdsAsync)}")
            .OrderBy(x => x.CreatedAt)
            .Skip(pagination.Offset)
            .Take(pagination.Limit)
            .ToArrayAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Additive>> GetListByIdsAsync(
        IReadOnlyCollection<Guid> additiveIds,
        CancellationToken cancellationToken)
    {
        return await dbContext.Additives
            .TagWith($"{nameof(AdditiveRepository)} - {nameof(GetListByIdsAsync)}")
            .Where(x => additiveIds.Contains(x.Id))
            .ToArrayAsync(cancellationToken);
    }

    public void Add(Additive additive)
    {
        dbContext.Additives.Add(additive);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}