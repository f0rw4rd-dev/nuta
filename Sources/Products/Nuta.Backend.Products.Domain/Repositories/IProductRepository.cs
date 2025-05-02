using Nuta.Backend.Products.Domain.Aggregates;

namespace Nuta.Backend.Products.Domain.Repositories;

public interface IProductRepository
{
    Task<IReadOnlyCollection<Product>> GetListAsync(
        IReadOnlyCollection<Guid> productIds,
        CancellationToken cancellationToken);
}