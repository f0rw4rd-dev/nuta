using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Products.Domain.Aggregates;

namespace Nuta.Backend.Products.Domain.Repositories;

public interface IProductRepository
{
    ValueTask<Product?> GetByIdAsync(Guid productId, CancellationToken cancellationToken);
    
    Task<Product?> GetByEan13Async(string ean13, CancellationToken cancellationToken);
    
    Task<IReadOnlyCollection<Product>> GetListAsync(Pagination pagination, CancellationToken cancellationToken);
    
    Task<IReadOnlyCollection<Product>> GetListByIdsAsync(
        IReadOnlyCollection<Guid> productIds, 
        Pagination pagination, 
        CancellationToken cancellationToken);
    
    void Add(Product product);
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}