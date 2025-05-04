using MediatR;
using Nuta.Backend.Products.Application.Dtos;

namespace Nuta.Backend.Products.Application.Queries.GetManufacturer;

public record GetManufacturerQuery(Guid ManufacturerId) : IRequest<ManufacturerDto>;