using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuta.Backend.Users.Domain.Aggregates;

namespace Nuta.Backend.Users.Infrastructure.Postgres.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name).IsRequired();
        builder.Property(user => user.AvatarKey);
        builder.Property(user => user.CreatedAt).IsRequired();
        builder.Property(user => user.UpdatedAt).IsRequired();

        builder.OwnsOne(user => user.FoodPreferences, navBuilder => navBuilder.ToJson());

        builder.OwnsMany(user => user.FavoriteProducts, navBuilder =>
        {
            navBuilder.WithOwner().HasForeignKey(userFavoriteProduct => userFavoriteProduct.UserId);

            navBuilder.HasKey(userFavoriteProduct => new { userFavoriteProduct.UserId, userFavoriteProduct.ProductId });
            
            navBuilder.Property(userFavoriteProduct => userFavoriteProduct.LikedAt).IsRequired();
        });

        builder.OwnsMany(user => user.ViewedProducts, navBuilder =>
        {
            navBuilder.WithOwner().HasForeignKey(userProductView => userProductView.UserId);

            navBuilder.HasKey(userProductView => new { userProductView.UserId, userProductView.ProductId });
            
            navBuilder.Property(userProductView => userProductView.ViewedAt).IsRequired();
        });
    }
}