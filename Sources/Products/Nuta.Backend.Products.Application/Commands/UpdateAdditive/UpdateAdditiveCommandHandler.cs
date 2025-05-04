using MediatR;
using Nuta.Backend.Products.Domain.Exceptions;
using Nuta.Backend.Products.Domain.Repositories;

namespace Nuta.Backend.Products.Application.Commands.UpdateAdditive;

public class UpdateAdditiveCommandHandler(IAdditiveRepository additiveRepository)
    : IRequestHandler<UpdateAdditiveCommand, Unit>
{
    public async Task<Unit> Handle(UpdateAdditiveCommand request, CancellationToken cancellationToken)
    {
        var additive = await additiveRepository.GetByIdAsync(request.AdditiveId, cancellationToken)
                       ?? throw new AdditiveNotFoundException(request.AdditiveId);

        if (request.Name.HasValue)
            additive.SetName(request.Name.Value);

        if (request.ChemicalName.HasValue)
            additive.SetChemicalName(request.ChemicalName.Value);

        if (request.ENumber.HasValue)
            additive.SetENumber(request.ENumber.Value);

        if (request.Description.HasValue)
            additive.SetDescription(request.Description.Value);

        if (request.RiskLevel.HasValue)
            additive.SetRiskLevel(request.RiskLevel.Value);

        await additiveRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}