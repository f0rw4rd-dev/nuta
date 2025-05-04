using Nuta.Backend.BuildingBlocks.Application.Structs;
using Nuta.Backend.Products.Domain.Enums;

namespace Nuta.Backend.Products.Application.Models.Requests;

public record UpdateAdditiveRequest(
    Optional<string> Name,
    Optional<string> ChemicalName,
    Optional<string?> ENumber,
    Optional<string?> Description,
    Optional<AdditiveRiskLevel> RiskLevel);