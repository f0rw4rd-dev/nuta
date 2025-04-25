using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuta.Backend.Products.Domain.Aggregates.Manufacturer;

namespace Nuta.Backend.Products.Infrastructure.Persistence.Relational.EntityTypeConfigurations;

public class ManufacturerEntityTypeConfiguration : IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        builder.HasKey(manufacturer => manufacturer.Id);
        
        builder.Property(manufacturer => manufacturer.Name).IsRequired();
        builder.Property(manufacturer => manufacturer.Description);
        builder.Property(manufacturer => manufacturer.CreatedAt).IsRequired();
        builder.Property(manufacturer => manufacturer.UpdatedAt).IsRequired();
    }
}