using MediatR;
using Nuta.Backend.Products.Application.Dtos;

namespace Nuta.Backend.Products.Application.Queries.GetProductDetailByEan13;

public record GetProductDetailByEan13Query(string Ean13) : IRequest<ProductDetailDto>;