using Nuta.Backend.Products.Domain.Enums;
using Nuta.Backend.Products.Domain.ValueObjects;

namespace Nuta.Backend.Products.Application.Dtos;

public record ProductDetailDto(
    Guid Id,
    string Name,
    string? Description,
    string? Ean13,
    ProductCategory Category,
    ProductSubCategory? SubCategory,
    Guid ManufacturerId,
    NutritionFacts NutritionFacts,
    Ingredients Ingredients,
    ProductLabels? Labels,
    double? UserScore,
    ExternalScores? ExternalScores,
    bool IsHidden);