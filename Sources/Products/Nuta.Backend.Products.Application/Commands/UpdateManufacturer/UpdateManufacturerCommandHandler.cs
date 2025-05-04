using MediatR;
using Nuta.Backend.Products.Domain.Exceptions;
using Nuta.Backend.Products.Domain.Repositories;

namespace Nuta.Backend.Products.Application.Commands.UpdateManufacturer;

public class UpdateManufacturerCommandHandler(IManufacturerRepository manufacturerRepository)
    : IRequestHandler<UpdateManufacturerCommand, Unit>
{
    public async Task<Unit> Handle(UpdateManufacturerCommand request, CancellationToken cancellationToken)
    {
        var manufacturer = await manufacturerRepository.GetByIdAsync(request.ManufacturerId, cancellationToken)
                           ?? throw new ManufacturerNotFoundException(request.ManufacturerId);

        if (request.Name.HasValue)
            manufacturer.SetName(request.Name.Value);

        if (request.Description.HasValue)
            manufacturer.SetDescription(request.Description.Value);

        return Unit.Value;
    }
}