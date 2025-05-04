using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Users.Domain.Aggregates;

namespace Nuta.Backend.Users.Domain.Repositories;

public interface IUserRepository
{
    ValueTask<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken);
    
    Task<IReadOnlyCollection<User>> GetListAsync(Pagination pagination, CancellationToken cancellationToken);
    
    void Add(User user);
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}