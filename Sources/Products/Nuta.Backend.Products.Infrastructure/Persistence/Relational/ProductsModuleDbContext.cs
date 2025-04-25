using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nuta.Backend.BuildingBlocks.Infrastructure.Inbox;
using Nuta.Backend.BuildingBlocks.Infrastructure.Outbox;
using Nuta.Backend.Products.Domain.Aggregates.Additive;
using Nuta.Backend.Products.Domain.Aggregates.Manufacturer;
using Nuta.Backend.Products.Domain.Aggregates.Product;
using Nuta.Backend.Products.Domain.Aggregates.ProductProposal;
using Nuta.Backend.Products.Options;

namespace Nuta.Backend.Products.Infrastructure.Persistence.Relational;

public class ProductsModuleDbContext(
    DbContextOptions<ProductsModuleDbContext> dbContextOptions, 
    IOptions<ProductsModuleOptions> moduleOptions)
    : DbContext(dbContextOptions)
{
    public DbSet<Product> Products { get; set; }
    
    public DbSet<ProductReview> ProductReviews { get; set; }
    
    public DbSet<ProductProposal> ProductProposals { get; set; }
    
    public DbSet<Manufacturer> Manufacturers { get; set; }
    
    public DbSet<Additive> Additives { get; set; }
    
    public DbSet<OutboxMessage> OutboxMessages { get; set; }
    
    public DbSet<InboxMessage> InboxMessages { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(moduleOptions.Value.Postgres.Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductsModuleDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}