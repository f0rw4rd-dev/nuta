using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuta.Backend.Products.Domain.Aggregates;

namespace Nuta.Backend.Products.Infrastructure.Postgres.Configurations;

public class AdditiveConfiguration : IEntityTypeConfiguration<Additive>
{
    public void Configure(EntityTypeBuilder<Additive> builder)
    {
        builder.HasKey(additive => additive.Id);
        
        builder.Property(additive => additive.Id).ValueGeneratedNever();
        builder.Property(additive => additive.Name).IsRequired();
        builder.Property(additive => additive.ChemicalName).IsRequired();
        builder.Property(additive => additive.ENumber);
        builder.Property(additive => additive.Description);
        builder.Property(additive => additive.RiskLevel).IsRequired();
        builder.Property(additive => additive.CreatedAt).IsRequired();
        builder.Property(additive => additive.UpdatedAt).IsRequired();
    }
}