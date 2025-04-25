using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nuta.BuildingBlocks.Infrastructure.Inbox;
using Nuta.BuildingBlocks.Infrastructure.Outbox;
using Nuta.Users.Domain.Aggregates.User;
using Nuta.Users.Options;

namespace Nuta.Users.Infrastructure.Persistence.Relational;

internal class UsersModuleDbContext(
    DbContextOptions<UsersModuleDbContext> options,
    IOptions<UsersModuleOptions> moduleOptions)
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    public DbSet<UserFavoriteProduct> UserFavoriteProducts { get; set; }

    public DbSet<UserProductView> UserProductViews { get; set; }
    
    public DbSet<OutboxMessage> OutboxMessages { get; set; }
    
    public DbSet<InboxMessage> InboxMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(moduleOptions.Value.Postgres.Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersModuleDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}