using Nuta.Backend.Products.Domain.Enums;

namespace Nuta.Backend.Products.Application.Models.Requests;

public record CreateAdditiveRequest(
    string Name,
    string ChemicalName,
    string? ENumber,
    string? Description,
    AdditiveRiskLevel RiskLevel);