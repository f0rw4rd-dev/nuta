namespace Nuta.Backend.Products.Application.Dtos;

public record ProductPreviewDto(
    Guid Id,
    string Name,
    string ManufacturerName,
    double? UserScore,
    int NutaScore,
    bool IsHidden);