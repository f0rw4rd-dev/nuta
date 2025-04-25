using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuta.Backend.Products.Domain.Aggregates.ProductProposal;

namespace Nuta.Backend.Products.Infrastructure.Persistence.Relational.EntityTypeConfigurations;

public class ProductProposalEntityTypeConfiguration : IEntityTypeConfiguration<ProductProposal>
{
    public void Configure(EntityTypeBuilder<ProductProposal> builder)
    {
        builder.HasKey(proposal => proposal.Id);
        
        builder.Property(proposal => proposal.ProductId);
        builder.Property(proposal => proposal.UserId).IsRequired();
        builder.Property(proposal => proposal.Name).IsRequired();
        builder.Property(proposal => proposal.Details).IsRequired();
        builder.Property(proposal => proposal.IsApproved).IsRequired();
        builder.Property(proposal => proposal.CreatedAt).IsRequired();
    }
}