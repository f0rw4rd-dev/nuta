using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuta.Users.Domain.Aggregates.User;

namespace Nuta.Users.Infrastructure.Persistence.Relational.EntityTypeConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name).IsRequired();
        builder.Property(user => user.AvatarKey);
        builder.Property(user => user.CreatedAt);
        builder.Property(user => user.UpdatedAt);

        builder.OwnsOne(user => user.FoodPreferences, navBuilder =>
        {
            navBuilder.ToJson();
        });

        builder.OwnsMany(user => user.FavoriteProducts, navBuilder =>
        {
            navBuilder.WithOwner().HasForeignKey(userFavoriteProduct => userFavoriteProduct.UserId);

            navBuilder.HasKey(userProductView => new { userProductView.UserId, userProductView.ProductId });
        });

        builder.OwnsMany(user => user.ViewedProducts, navBuilder =>
        {
            navBuilder.WithOwner().HasForeignKey(userProductView => userProductView.UserId);

            navBuilder.HasKey(userProductView => new { userProductView.UserId, userProductView.ProductId });
            
            navBuilder.Property(userProductView => userProductView.ViewedAt).IsRequired();
        });
    }
}