using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuta.Backend.Products.Domain.Aggregates.Additive;

namespace Nuta.Backend.Products.Infrastructure.Persistence.Relational.EntityTypeConfigurations;

public class AdditiveEntityTypeConfiguration : IEntityTypeConfiguration<Additive>
{
    public void Configure(EntityTypeBuilder<Additive> builder)
    {
        builder.HasKey(additive => additive.Id);
        
        builder.Property(additive => additive.Name).IsRequired();
        builder.Property(additive => additive.ChemicalName).IsRequired();
        builder.Property(additive => additive.ENumber);
        builder.Property(additive => additive.Description);
        builder.Property(additive => additive.RiskLevel).IsRequired();
        builder.Property(additive => additive.CreatedAt).IsRequired();
        builder.Property(additive => additive.UpdatedAt).IsRequired();
    }
}