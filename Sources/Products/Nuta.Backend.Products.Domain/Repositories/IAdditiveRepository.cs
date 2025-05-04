using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Products.Domain.Aggregates;

namespace Nuta.Backend.Products.Domain.Repositories;

public interface IAdditiveRepository
{
    ValueTask<Additive?> GetByIdAsync(Guid additiveId, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<Additive>> GetListAsync(Pagination pagination, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<Additive>> GetListByIdsAsync(
        IReadOnlyCollection<Guid> additiveIds,
        CancellationToken cancellationToken);

    void Add(Additive additive);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}