using System.Diagnostics.CodeAnalysis;
using Nuta.Backend.BuildingBlocks.Domain;
using Nuta.Backend.Users.Domain.BusinessRules;
using Nuta.Backend.Users.Domain.DomainEvents;
using Nuta.Backend.Users.Domain.Entities;
using Nuta.Backend.Users.Domain.ValueObjects;

namespace Nuta.Backend.Users.Domain.Aggregates;

public class User : Entity, IAggregateRoot
{
    public Guid Id { get; }

    public string Name { get; private set; } = null!;

    public string? AvatarKey { get; private set; }
    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; private set; }

    public FoodPreferences FoodPreferences { get; private set; } = null!;

    private readonly List<UserFavoriteProduct> _favoriteProducts = [];

    private readonly List<UserViewedProduct> _viewedProducts = [];

    public IReadOnlyCollection<UserFavoriteProduct> FavoriteProducts => _favoriteProducts;

    public IReadOnlyCollection<UserViewedProduct> ViewedProducts => _viewedProducts;

    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private User()
    {
        // EF Core
    }

    private User(Guid id, string name)
    {
        CheckRule(new UserNameMustHaveValidLengthRule(name));

        Id = id;
        Name = name.Trim();
        FoodPreferences = FoodPreferences.Create();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;

        AddDomainEvent(new UserCreatedDomainEvent(Id));
    }

    public static User Create(string name)
    {
        return new User(id: Guid.CreateVersion7(), name);
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

    public void AddFavoriteProduct(Guid productId)
    {
        CheckRule(new UserCannotAddDuplicateFavoriteProductRule(FavoriteProducts, productId));

        _favoriteProducts.Add(UserFavoriteProduct.Create(Id, productId));

        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveFavoriteProduct(Guid productId)
    {
        CheckRule(new UserCannotRemoveNonFavoriteProductRule(FavoriteProducts, productId));

        var product = _favoriteProducts.First(x => x.ProductId == productId);
        _favoriteProducts.Remove(product);

        UpdatedAt = DateTime.UtcNow;
    }

    public void ViewProduct(Guid productId)
    {
        var viewedProduct = _viewedProducts.FirstOrDefault(x => x.ProductId == productId);

        if (viewedProduct is null)
            _viewedProducts.Add(UserViewedProduct.Create(Id, productId));
        else
            viewedProduct.UpdateViewedAt();
    }

    public void SetFoodPreferences(FoodPreferences foodPreferences)
    {
        FoodPreferences = foodPreferences;
        UpdatedAt = DateTime.UtcNow;
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