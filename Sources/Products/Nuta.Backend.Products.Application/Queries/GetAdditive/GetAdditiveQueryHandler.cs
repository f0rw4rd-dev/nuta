using MediatR;
using Nuta.Backend.Products.Application.Dtos;
using Nuta.Backend.Products.Domain.Exceptions;
using Nuta.Backend.Products.Domain.Repositories;

namespace Nuta.Backend.Products.Application.Queries.GetAdditive;

public class GetAdditiveQueryHandler(IAdditiveRepository additiveRepository)
    : IRequestHandler<GetAdditiveQuery, AdditiveDto>
{
    public async Task<AdditiveDto> Handle(GetAdditiveQuery request, CancellationToken cancellationToken)
    {
        var additive = await additiveRepository.GetByIdAsync(request.AdditiveId, cancellationToken)
                       ?? throw new AdditiveNotFoundException(request.AdditiveId);

        return new AdditiveDto(
            additive.Id,
            additive.Name,
            additive.ChemicalName,
            additive.ENumber,
            additive.Description,
            additive.RiskLevel);
    }
}