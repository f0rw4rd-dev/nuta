using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Products.Domain.Aggregates;

namespace Nuta.Backend.Products.Domain.Repositories;

public interface IManufacturerRepository
{
    ValueTask<Manufacturer?> GetByIdAsync(Guid manufacturerId, CancellationToken cancellationToken);
    
    Task<IReadOnlyCollection<Manufacturer>> GetListAsync(Pagination pagination, CancellationToken cancellationToken);
    
    void Add(Manufacturer manufacturer);
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}