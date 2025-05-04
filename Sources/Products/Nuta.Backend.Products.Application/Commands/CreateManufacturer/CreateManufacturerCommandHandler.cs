using MediatR;
using Nuta.Backend.Products.Domain.Aggregates;
using Nuta.Backend.Products.Domain.Repositories;

namespace Nuta.Backend.Products.Application.Commands.CreateManufacturer;

public class CreateManufacturerCommandHandler(IManufacturerRepository manufacturerRepository)
    : IRequestHandler<CreateManufacturerCommand, Guid>
{
    public async Task<Guid> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
    {
        var manufacturer = Manufacturer.Create(request.Name, request.Description);

        manufacturerRepository.Add(manufacturer);
        await manufacturerRepository.SaveChangesAsync(cancellationToken);

        return manufacturer.Id;
    }
}