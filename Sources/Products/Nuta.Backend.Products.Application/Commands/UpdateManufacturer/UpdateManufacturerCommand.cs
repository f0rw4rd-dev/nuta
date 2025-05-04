using MediatR;
using Nuta.Backend.BuildingBlocks.Application.Structs;

namespace Nuta.Backend.Products.Application.Commands.UpdateManufacturer;

public record UpdateManufacturerCommand(
    Guid ManufacturerId,
    Optional<string> Name,
    Optional<string?> Description)
    : IRequest<Unit>;