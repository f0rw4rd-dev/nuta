using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuta.Backend.Products.Domain.Aggregates;

namespace Nuta.Backend.Products.Infrastructure.Postgres.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(product => product.Id);

        builder.Property(product => product.Id).ValueGeneratedNever();
        builder.Property(product => product.Name).IsRequired();
        builder.Property(product => product.Description);
        builder.Property(product => product.Ean13);
        builder.Property(product => product.ImageKey);
        builder.Property(product => product.Category).IsRequired();
        builder.Property(product => product.SubCategory);
        builder.Property(product => product.UserScore);
        builder.Property(product => product.IsHidden).IsRequired();
        builder.Property(product => product.CreatedAt).IsRequired();
        builder.Property(product => product.UpdatedAt).IsRequired();

        builder.OwnsOne(product => product.NutritionFacts, navBuilder => navBuilder.ToJson());
        builder.OwnsOne(product => product.Ingredients, navBuilder => navBuilder.ToJson());
        builder.OwnsOne(product => product.Labels, navBuilder => navBuilder.ToJson());
        builder.OwnsOne(product => product.ExternalScores, navBuilder => navBuilder.ToJson());

        builder.OwnsMany(product => product.UserReviews, navBuilder =>
        {
            navBuilder.WithOwner().HasForeignKey(review => review.ProductId);

            navBuilder.HasKey(review => new { review.ProductId, review.UserId });

            navBuilder.Property(review => review.ProductId).ValueGeneratedNever();
            navBuilder.Property(review => review.UserId).ValueGeneratedNever();
            navBuilder.Property(review => review.Rating).IsRequired();
            navBuilder.Property(review => review.Comment);
            navBuilder.Property(review => review.IsHidden).IsRequired();
            navBuilder.Property(review => review.CreatedAt).IsRequired();
            navBuilder.Property(review => review.UpdatedAt).IsRequired();
        });

        builder.HasOne(product => product.Manufacturer).WithMany().HasForeignKey(product => product.ManufacturerId);
        
        builder.HasIndex(product => product.Ean13).IsUnique();
    }
}