using Nuta.Backend.Products.Domain.Enums;

namespace Nuta.Backend.Products.Application.Dtos;

public record AdditiveDto(
    Guid Id,
    string Name,
    string ChemicalName,
    string? ENumber,
    string? Description,
    AdditiveRiskLevel RiskLevel);