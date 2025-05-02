using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuta.Backend.Products.Domain.Aggregates;

namespace Nuta.Backend.Products.Infrastructure.Postgres.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(product => product.Id);

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
            navBuilder.WithOwner().HasForeignKey(productReview => productReview.ProductId);

            navBuilder.HasKey(productReview => new { productReview.ProductId, productReview.UserId });

            navBuilder.Property(productReview => productReview.Rating).IsRequired();
            navBuilder.Property(productReview => productReview.Comment);
            navBuilder.Property(productReview => productReview.IsHidden).IsRequired();
            navBuilder.Property(productReview => productReview.CreatedAt).IsRequired();
            navBuilder.Property(productReview => productReview.UpdatedAt).IsRequired();
        });

        builder.HasOne(product => product.Manufacturer).WithMany().HasForeignKey(product => product.ManufacturerId);
    }
}