using MediatR;
using Nuta.Backend.BuildingBlocks.Application.Structs;
using Nuta.Backend.Products.Domain.Enums;

namespace Nuta.Backend.Products.Application.Commands.UpdateAdditive;

public record UpdateAdditiveCommand(
    Guid AdditiveId,
    Optional<string> Name,
    Optional<string> ChemicalName,
    Optional<string?> ENumber,
    Optional<string?> Description,
    Optional<AdditiveRiskLevel> RiskLevel)
    : IRequest<Unit>;