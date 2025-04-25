using Nuta.Backend.BuildingBlocks.Domain;
using Nuta.Backend.Products.Domain.Aggregates.Manufacturer;
using Nuta.Backend.Products.Domain.Aggregates.Product.Enums;
using Nuta.Backend.Products.Domain.Aggregates.Product.ValueObjects;

namespace Nuta.Backend.Products.Domain.Aggregates.Product;

public class Product : Entity, IAggregateRoot
{
    public ProductId Id { get; }
    
    public string Name { get; private set; }
    
    public string? Description { get; private set; }
    
    public string? Ean13 { get; private set; }
    
    public ProductCategory Category { get; private set; }
    
    public ManufacturerId ManufacturerId { get; private set; }
    
    public Manufacturer.Manufacturer Manufacturer { get; private set; }
    
    public NutritionFacts NutritionFacts { get; private set; }
    
    public bool IsHidden { get; private set; }
    
    
    public string ImageKey { get; private set; }
    
    public Ingredients Ingredients { get; private set; }
    
    public Labels Labels { get; private set; }
    
    public float? UserScore { get; private set; }
    
    public ExternalScores? ExternalScores { get; private set; }
    
    public IReadOnlyCollection<ProductReview> Reviews => _reviews.AsReadOnly();
    
    private readonly List<ProductReview> _reviews = [];
    
    public DateTime CreatedAt { get; }
    
    public DateTime UpdatedAt { get; private set; }

    private Product()
    {
    }
    
    private Product(
        ProductId id, 
        string ean13,
        ProductCategory category,
        Manufacturer.Manufacturer manufacturer, 
        bool isHidden,
        NutritionFacts? nutritionFacts = null)
    {
        Id = id;
        Ean13 = ean13;
        Category = category;
        Manufacturer = manufacturer;
        IsHidden = isHidden;
        NutritionFacts = nutritionFacts;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public static Product Create(
        ProductId id, 
        string ean13,
        ProductCategory category,
        Manufacturer.Manufacturer manufacturer, 
        bool isHidden,
        NutritionFacts? nutritionFacts = null)
    {
        return new Product(id, ean13, category, manufacturer, isHidden, nutritionFacts);
    }
    
    public void SetCategory(ProductCategory category)
    {
        Category = category;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void SetManufacturer(Manufacturer.Manufacturer manufacturer)
    {
        Manufacturer = manufacturer;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void SetNutritionFacts(NutritionFacts nutritionFacts)
    {
        NutritionFacts = nutritionFacts;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void SetHidden(bool isHidden)
    {
        IsHidden = isHidden;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void SetLabels(Labels labels)
    {
        Labels = labels;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void AddReview(ProductReview review)
    {
        _reviews.Add(review);
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void RemoveReview(ProductReview review)
    {
        _reviews.Remove(review);
        UpdatedAt = DateTime.UtcNow;
    }
}