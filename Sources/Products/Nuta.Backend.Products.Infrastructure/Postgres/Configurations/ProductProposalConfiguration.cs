using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuta.Backend.Products.Domain.Aggregates;

namespace Nuta.Backend.Products.Infrastructure.Postgres.Configurations;

public class ProductProposalConfiguration : IEntityTypeConfiguration<ProductProposal>
{
    public void Configure(EntityTypeBuilder<ProductProposal> builder)
    {
        builder.HasKey(proposal => proposal.Id);
        
        builder.Property(proposal => proposal.ProductId);
        builder.Property(proposal => proposal.UserId).IsRequired();
        builder.Property(proposal => proposal.Name).IsRequired();
        builder.Property(proposal => proposal.Details).IsRequired();
        builder.Property(proposal => proposal.Status).IsRequired();
        builder.Property(proposal => proposal.CreatedAt).IsRequired();
    }
}