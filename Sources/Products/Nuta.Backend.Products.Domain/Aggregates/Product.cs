using System.Diagnostics.CodeAnalysis;
using Nuta.Backend.BuildingBlocks.Domain;
using Nuta.Backend.Products.Domain.BusinessRules;
using Nuta.Backend.Products.Domain.Entities;
using Nuta.Backend.Products.Domain.Enums;
using Nuta.Backend.Products.Domain.ValueObjects;

namespace Nuta.Backend.Products.Domain.Aggregates;

public class Product : Entity, IAggregateRoot
{
    public Guid Id { get; }

    public string Name { get; private set; } = null!;

    public string? Description { get; private set; }

    public string? Ean13 { get; private set; }

    public string? ImageKey { get; private set; }

    public ProductCategory Category { get; private set; }

    public ProductSubCategory? SubCategory { get; private set; }
    
    public Guid ManufacturerId { get; private set; }

    public Manufacturer Manufacturer { get; private set; } = null!;

    public NutritionFacts NutritionFacts { get; private set; } = null!;

    public Ingredients Ingredients { get; private set; } = null!;

    public ProductLabels? Labels { get; private set; }

    public double? UserScore { get; private set; }

    public ExternalScores? ExternalScores { get; private set; }

    private readonly List<ProductUserReview> _userReviews = [];

    public bool IsHidden { get; private set; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; private set; }

    public IReadOnlyCollection<ProductUserReview> UserReviews => _userReviews.AsReadOnly();

    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private Product()
    {
        // EF Core
    }

    private Product(
        Guid id,
        string name,
        string? description,
        string? ean13,
        string? imageKey,
        ProductCategory category,
        ProductSubCategory? subCategory,
        Manufacturer manufacturer,
        NutritionFacts nutritionFacts,
        Ingredients ingredients,
        ProductLabels? labels,
        ExternalScores? externalScores)
    {
        if (ean13 is not null)
            CheckRule(new Ean13MustHaveValidLengthRule(ean13));

        Id = id;
        Name = name;
        Description = description;
        Ean13 = ean13;
        ImageKey = imageKey;
        Category = category;
        SubCategory = subCategory;
        Manufacturer = manufacturer;
        ManufacturerId = manufacturer.Id;
        NutritionFacts = nutritionFacts;
        Ingredients = ingredients;
        Labels = labels;
        UserScore = null;
        ExternalScores = externalScores;
        IsHidden = false;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public static Product Create(
        string name,
        string? description,
        string? ean13,
        string? imageKey,
        ProductCategory category,
        ProductSubCategory? subCategory,
        Manufacturer manufacturer,
        NutritionFacts nutritionFacts,
        Ingredients ingredients,
        ProductLabels? labels,
        ExternalScores? externalScores)
    {
        return new Product(
            id: Guid.CreateVersion7(),
            name,
            description,
            ean13,
            imageKey,
            category,
            subCategory,
            manufacturer,
            nutritionFacts,
            ingredients,
            labels,
            externalScores);
    }

    public void SetName(string name)
    {
        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetDescription(string? description)
    {
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetImage(string imageKey)
    {
        ImageKey = imageKey;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ClearImage()
    {
        ImageKey = null;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetCategory(ProductCategory category)
    {
        Category = category;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void SetSubCategory(ProductSubCategory? subCategory)
    {
        SubCategory = subCategory;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetManufacturer(Manufacturer manufacturer)
    {
        Manufacturer = manufacturer;
        ManufacturerId = manufacturer.Id;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetNutritionFacts(NutritionFacts nutritionFacts)
    {
        NutritionFacts = nutritionFacts;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void SetIngredients(Ingredients ingredients)
    {
        Ingredients = ingredients;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void SetLabels(ProductLabels productLabels)
    {
        Labels = productLabels;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void ClearLabels()
    {
        Labels = null;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void SetExternalScores(ExternalScores? externalScores)
    {
        ExternalScores = externalScores;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Hide()
    {
        IsHidden = true;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Unhide()
    {
        IsHidden = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddUserReview(ProductUserReview userReview)
    {
        CheckRule(new UserCannotLeaveMultipleReviewsForSameProductRule(UserReviews, userReview.UserId));
        
        _userReviews.Add(userReview);
        UserScore = UserReviews.Average(x => x.Rating);
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveUserReview(ProductUserReview userReview)
    {
        CheckRule(new UserCannotRemoveNonExistentReviewRule(UserReviews, userReview.UserId));
        
        _userReviews.Remove(userReview);
        UserScore = UserReviews.Average(x => x.Rating);
        UpdatedAt = DateTime.UtcNow;
    }
}