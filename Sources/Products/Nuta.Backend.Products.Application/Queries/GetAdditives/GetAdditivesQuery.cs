using MediatR;
using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Products.Application.Dtos;

namespace Nuta.Backend.Products.Application.Queries.GetAdditives;

public record GetAdditivesQuery(Pagination Pagination) : IRequest<IReadOnlyCollection<AdditiveDto>>;