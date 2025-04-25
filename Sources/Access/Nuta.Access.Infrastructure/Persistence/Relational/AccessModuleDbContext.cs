using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nuta.Access.Domain.Entities;
using Nuta.Access.Options;
using Nuta.BuildingBlocks.Infrastructure.Outbox;

namespace Nuta.Access.Infrastructure.Persistence.Relational;

public class AccessModuleDbContext(
    DbContextOptions<AccessModuleDbContext> dbContextOptions,
    IOptions<AccessModuleOptions> moduleOptions)
    : IdentityDbContext<IdentityUser, IdentityRole, Guid>(dbContextOptions)
{
    public DbSet<OutboxMessage> OutboxMessages { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(moduleOptions.Value.Postgres.Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccessModuleDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}