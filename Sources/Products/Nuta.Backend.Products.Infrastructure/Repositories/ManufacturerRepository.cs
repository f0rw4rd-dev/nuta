using Microsoft.EntityFrameworkCore;
using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Products.Domain.Aggregates;
using Nuta.Backend.Products.Domain.Repositories;
using Nuta.Backend.Products.Infrastructure.Postgres;

namespace Nuta.Backend.Products.Infrastructure.Repositories;

public class ManufacturerRepository(ProductsModuleDbContext dbContext) : IManufacturerRepository
{
    public ValueTask<Manufacturer?> GetByIdAsync(Guid manufacturerId, CancellationToken cancellationToken)
    {
        return dbContext.Manufacturers.FindAsync([manufacturerId], cancellationToken);
    }

    public async Task<IReadOnlyCollection<Manufacturer>> GetListAsync(Pagination pagination,
        CancellationToken cancellationToken)
    {
        return await dbContext.Manufacturers
            .TagWith($"{nameof(ManufacturerRepository)} - {nameof(GetListAsync)}")
            .OrderBy(x => x.CreatedAt)
            .Skip(pagination.Offset)
            .Take(pagination.Limit)
            .ToArrayAsync(cancellationToken);
    }

    public void Add(Manufacturer manufacturer)
    {
        dbContext.Manufacturers.Add(manufacturer);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}