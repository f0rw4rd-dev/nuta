using Nuta.Backend.Users.Domain.Aggregates;
using Nuta.Backend.Users.Domain.Repositories;
using Nuta.Backend.Users.Infrastructure.Postgres;

namespace Nuta.Backend.Users.Infrastructure.Repositories;

public class UserRepository(UsersModuleDbContext dbContext) : IUserRepository
{
    public ValueTask<User?> GetAsync(Guid userId, CancellationToken cancellationToken)
    {
        return dbContext.FindAsync<User>([userId], cancellationToken);
    }
}