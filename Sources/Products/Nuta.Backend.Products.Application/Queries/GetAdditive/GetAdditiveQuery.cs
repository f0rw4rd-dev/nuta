using MediatR;
using Nuta.Backend.Products.Application.Dtos;

namespace Nuta.Backend.Products.Application.Queries.GetAdditive;

public record GetAdditiveQuery(Guid AdditiveId) : IRequest<AdditiveDto>;