namespace Nuta.Backend.Products.Application.Dtos;

public record ProductShortInfoDto(Guid Id, string ProductName, string ManufacturerName, double? UserScore, int NutaScore);