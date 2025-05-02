using Nuta.Backend.Users.Domain.Aggregates;

namespace Nuta.Backend.Users.Domain.Repositories;

public interface IUserRepository
{
    ValueTask<User?> GetAsync(Guid userId, CancellationToken cancellationToken);
}