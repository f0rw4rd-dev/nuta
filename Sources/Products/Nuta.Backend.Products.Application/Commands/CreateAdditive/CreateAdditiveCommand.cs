using MediatR;
using Nuta.Backend.Products.Domain.Enums;

namespace Nuta.Backend.Products.Application.Commands.CreateAdditive;

public record CreateAdditiveCommand(
    string Name,
    string ChemicalName,
    string? ENumber,
    string? Description,
    AdditiveRiskLevel RiskLevel)
    : IRequest<Guid>;