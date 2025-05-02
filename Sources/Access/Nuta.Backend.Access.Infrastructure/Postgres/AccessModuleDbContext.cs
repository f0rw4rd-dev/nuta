using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nuta.Backend.Access.Domain.Entities;
using Nuta.Backend.Access.Options;
using Nuta.Backend.BuildingBlocks.Infrastructure.Outbox;

namespace Nuta.Backend.Access.Infrastructure.Postgres;

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