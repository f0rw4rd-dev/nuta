using Nuta.Backend.BuildingBlocks.Domain;
using Nuta.Backend.Users.Domain.Aggregates.Product;
using Nuta.Backend.Users.Domain.Aggregates.User.Rules;
using Nuta.Backend.Users.Domain.Aggregates.User.ValueObjects;

namespace Nuta.Backend.Users.Domain.Aggregates.User;

public class User : Entity, IAggregateRoot
{
    public UserId Id { get; }
    
    public string Name { get; private set; }
    
    public string? AvatarKey { get; private set; }
    
    public DateTime CreatedAt { get; }
    
    public DateTime UpdatedAt { get; private set; }

    public FoodPreferences FoodPreferences { get; private set; }

    public IReadOnlyCollection<UserFavoriteProduct> FavoriteProducts => _favoriteProducts;
    
    public IReadOnlyCollection<UserProductView> ViewedProducts => _viewedProducts;

    private readonly List<UserFavoriteProduct> _favoriteProducts = [];
    
    private readonly List<UserProductView> _viewedProducts = [];
    
    private User()
    {
    }

    private User(string name)
    {
        CheckRule(new UserNameMustHaveValidLengthRule(name));

        Id = new UserId(Guid.CreateVersion7());
        Name = name.Trim();
        FoodPreferences = FoodPreferences.Create();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public static User Create(string name)
    {
        return new User(name);
    }

    public void SetName(string name)
    {
        CheckRule(new UserNameMustHaveValidLengthRule(name));

        Name = name.Trim();
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetAvatar(string avatarKey)
    {
        AvatarKey = avatarKey;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ClearAvatar()
    {
        AvatarKey = null;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddFavoriteProduct(ProductId productId)
    {
        CheckRule(new UserCannotAddDuplicateFavoriteProductRule(FavoriteProducts, productId));

        _favoriteProducts.Add(UserFavoriteProduct.Create(Id, productId));

        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveFavoriteProduct(ProductId productId)
    {
        CheckRule(new UserCannotRemoveNonFavoriteProductRule(FavoriteProducts, productId));

        var product = _favoriteProducts.First(p => p.ProductId == productId);
        _favoriteProducts.Remove(product);

        UpdatedAt = DateTime.UtcNow;
    }

    public void ViewProduct(ProductId productId)
    {
        _viewedProducts.Add(UserProductView.Create(Id, productId));
    }

    public void SetNutritionPreferences(NutritionPreferences nutritionPreferences)
    {
        FoodPreferences = FoodPreferences.WithNutritionPreferences(nutritionPreferences);
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetIngredientPreferences(IngredientPreferences ingredientsPreferences)
    {
        FoodPreferences = FoodPreferences.WithIngredientPreferences(ingredientsPreferences);
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetAllergenRestrictions(AllergenRestrictions allergenRestrictions)
    {
        FoodPreferences = FoodPreferences.WithAllergenRestrictions(allergenRestrictions);
        UpdatedAt = DateTime.UtcNow;
    }
}