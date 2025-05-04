using MediatR;
using Nuta.Backend.Products.Application.Dtos;

namespace Nuta.Backend.Products.Application.Queries.GetProductDetailById;

public record GetProductDetailByIdQuery(Guid ProductId) : IRequest<ProductDetailDto>;