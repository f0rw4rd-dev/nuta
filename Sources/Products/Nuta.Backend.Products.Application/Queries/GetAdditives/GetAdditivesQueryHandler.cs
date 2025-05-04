using MediatR;
using Nuta.Backend.Products.Application.Dtos;
using Nuta.Backend.Products.Domain.Repositories;

namespace Nuta.Backend.Products.Application.Queries.GetAdditives;

public class GetAdditivesQueryHandler(IAdditiveRepository additiveRepository)
    : IRequestHandler<GetAdditivesQuery, IReadOnlyCollection<AdditiveDto>>
{
    public async Task<IReadOnlyCollection<AdditiveDto>> Handle(
        GetAdditivesQuery request,
        CancellationToken cancellationToken)
    {
        var additives = await additiveRepository.GetListAsync(
            request.Pagination,
            cancellationToken);

        return additives
            .Select(additive => new AdditiveDto(
                additive.Id,
                additive.Name,
                additive.ChemicalName,
                additive.ENumber,
                additive.Description,
                additive.RiskLevel))
            .ToArray();
    }
}