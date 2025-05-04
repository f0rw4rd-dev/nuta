using MediatR;
using Nuta.Backend.Products.Application.Dtos;
using Nuta.Backend.Products.Domain.Exceptions;
using Nuta.Backend.Products.Domain.Repositories;

namespace Nuta.Backend.Products.Application.Queries.GetManufacturer;

public class GetManufacturerQueryHandler(IManufacturerRepository manufacturerRepository)
    : IRequestHandler<GetManufacturerQuery, ManufacturerDto>
{
    public async Task<ManufacturerDto> Handle(GetManufacturerQuery request, CancellationToken cancellationToken)
    {
        var additive = await manufacturerRepository.GetByIdAsync(request.ManufacturerId, cancellationToken)
                       ?? throw new ManufacturerNotFoundException(request.ManufacturerId);

        return new ManufacturerDto(additive.Id, additive.Name, additive.Description);
    }
}