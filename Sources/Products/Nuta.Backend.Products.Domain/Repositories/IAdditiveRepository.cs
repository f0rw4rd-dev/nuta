using Nuta.Backend.Products.Domain.Aggregates;

namespace Nuta.Backend.Products.Domain.Repositories;

public interface IAdditiveRepository
{
    Task<IReadOnlyCollection<Additive>> GetListAsync(
        IReadOnlyCollection<Guid> additiveIds,
        CancellationToken cancellationToken);
}