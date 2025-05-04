using MediatR;
using Nuta.Backend.Products.Application.Dtos;
using Nuta.Backend.Products.Domain.Repositories;

namespace Nuta.Backend.Products.Application.Queries.GetManufacturers;

public class GetManufacturersQueryHandler(IManufacturerRepository manufacturerRepository)
    : IRequestHandler<GetManufacturersQuery, IReadOnlyCollection<ManufacturerDto>>
{
    public async Task<IReadOnlyCollection<ManufacturerDto>> Handle(
        GetManufacturersQuery request,
        CancellationToken cancellationToken)
    {
        var manufacturers = await manufacturerRepository.GetListAsync(
            request.Pagination,
            cancellationToken);

        return manufacturers
            .Select(manufacturer => new ManufacturerDto(manufacturer.Id, manufacturer.Name, manufacturer.Description))
            .ToArray();
    }
}