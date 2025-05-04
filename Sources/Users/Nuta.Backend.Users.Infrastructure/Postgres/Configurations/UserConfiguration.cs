using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuta.Backend.Users.Domain.Aggregates;

namespace Nuta.Backend.Users.Infrastructure.Postgres.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Id).ValueGeneratedNever();
        builder.Property(user => user.Name).IsRequired();
        builder.Property(user => user.AvatarKey);
        builder.Property(user => user.CreatedAt).IsRequired();
        builder.Property(user => user.UpdatedAt).IsRequired();
        
        builder.OwnsOne(user => user.FoodPreferences, navBuilder => navBuilder.ToJson());
        
        builder.OwnsMany(user => user.FavoriteProducts, navBuilder =>
        {
            navBuilder.WithOwner().HasForeignKey(favoriteProduct => favoriteProduct.UserId);
            
            navBuilder.HasKey(favoriteProduct => new { favoriteProduct.UserId, favoriteProduct.ProductId });
            
            navBuilder.Property(favoriteProduct => favoriteProduct.UserId).ValueGeneratedNever();
            navBuilder.Property(favoriteProduct => favoriteProduct.ProductId).ValueGeneratedNever();
            navBuilder.Property(favoriteProduct => favoriteProduct.LikedAt).IsRequired();
        });
        
        builder.OwnsMany(user => user.ViewedProducts, navBuilder =>
        {
            navBuilder.WithOwner().HasForeignKey(viewedProduct => viewedProduct.UserId);
        
            navBuilder.HasKey(viewedProduct => new { viewedProduct.UserId, viewedProduct.ProductId });
        
            navBuilder.Property(viewedProduct => viewedProduct.UserId).IsRequired();
            navBuilder.Property(viewedProduct => viewedProduct.ProductId).IsRequired();
            navBuilder.Property(viewedProduct => viewedProduct.ViewedAt).IsRequired();
        });
    }
}