using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nuta.BuildingBlocks.Infrastructure.Inbox;
using Nuta.BuildingBlocks.Infrastructure.Outbox;
using Nuta.Products.Domain.Aggregates.Additive;
using Nuta.Products.Domain.Aggregates.Manufacturer;
using Nuta.Products.Domain.Aggregates.Product;
using Nuta.Products.Domain.Aggregates.ProductProposal;
using Nuta.Products.Options;

namespace Nuta.Products.Infrastructure.Persistence.Relational;

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