using MediatR;
using Nuta.Backend.Products.Domain.Enums;
using Nuta.Backend.Products.Domain.ValueObjects;

namespace Nuta.Backend.Products.Application.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    string? Description,
    string? Ean13,
    string? ImageKey,
    ProductCategory Category,
    ProductSubCategory? SubCategory,
    Guid ManufacturerId,
    NutritionFacts NutritionFacts,
    Ingredients Ingredients,
    ProductLabels? Labels,
    ExternalScores? ExternalScores)
    : IRequest<Guid>;