using Microsoft.EntityFrameworkCore;
using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Users.Domain.Aggregates;
using Nuta.Backend.Users.Domain.Repositories;
using Nuta.Backend.Users.Infrastructure.Postgres;

namespace Nuta.Backend.Users.Infrastructure.Repositories;

public class UserRepository(UsersModuleDbContext dbContext) : IUserRepository
{
    public ValueTask<User?> GetAsync(Guid userId, CancellationToken cancellationToken)
    {
        return dbContext.Users.FindAsync([userId], cancellationToken);
    }

    public async Task<IReadOnlyCollection<User>> GetListAsync(
        Pagination pagination,
        CancellationToken cancellationToken)
    {
        return await dbContext.Users
            .OrderBy(x => x.CreatedAt)
            .Skip(pagination.Offset)
            .Take(pagination.Limit)
            .ToArrayAsync(cancellationToken);
    }

    public void Add(User user)
    {
        dbContext.Users.Add(user);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    { 
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}