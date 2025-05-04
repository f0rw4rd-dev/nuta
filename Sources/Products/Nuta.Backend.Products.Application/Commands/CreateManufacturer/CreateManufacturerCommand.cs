using MediatR;

namespace Nuta.Backend.Products.Application.Commands.CreateManufacturer;

public record CreateManufacturerCommand(string Name, string? Description) : IRequest<Guid>;