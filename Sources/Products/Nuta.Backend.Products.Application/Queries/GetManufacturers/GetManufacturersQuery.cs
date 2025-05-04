using MediatR;
using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Products.Application.Dtos;

namespace Nuta.Backend.Products.Application.Queries.GetManufacturers;

public record GetManufacturersQuery(Pagination Pagination) : IRequest<IReadOnlyCollection<ManufacturerDto>>;