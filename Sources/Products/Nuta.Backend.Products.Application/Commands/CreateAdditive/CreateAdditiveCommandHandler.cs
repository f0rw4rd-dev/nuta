using MediatR;
using Nuta.Backend.Products.Domain.Aggregates;
using Nuta.Backend.Products.Domain.Repositories;

namespace Nuta.Backend.Products.Application.Commands.CreateAdditive;

public class CreateAdditiveCommandHandler(IAdditiveRepository additiveRepository)
    : IRequestHandler<CreateAdditiveCommand, Guid>
{
    public async Task<Guid> Handle(CreateAdditiveCommand request, CancellationToken cancellationToken)
    {
        var additive = Additive.Create(
            request.Name,
            request.ChemicalName,
            request.ENumber,
            request.Description,
            request.RiskLevel);

        additiveRepository.Add(additive);
        await additiveRepository.SaveChangesAsync(cancellationToken);

        return additive.Id;
    }
}