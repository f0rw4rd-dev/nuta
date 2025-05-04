using Nuta.Backend.BuildingBlocks.Application.Structs;
using Nuta.Backend.Products.Domain.Enums;
using Nuta.Backend.Products.Domain.ValueObjects;

namespace Nuta.Backend.Products.Application.Models.Requests;

public record UpdateProductRequest(
    Optional<string> Name,
    Optional<string?> Description,
    Optional<string?> Ean13,
    Optional<string?> ImageKey,
    Optional<ProductCategory> Category,
    Optional<ProductSubCategory?> SubCategory,
    Optional<Guid> ManufacturerId,
    Optional<NutritionFacts> NutritionFacts,
    Optional<Ingredients> Ingredients,
    Optional<ProductLabels?> Labels,
    Optional<ExternalScores?> ExternalScores);