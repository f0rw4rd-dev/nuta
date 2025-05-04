using MediatR;
using Nuta.Backend.Products.Application.Dtos;
using Nuta.Backend.Products.Domain.Exceptions;
using Nuta.Backend.Products.Domain.Repositories;

namespace Nuta.Backend.Products.Application.Queries.GetProductDetailByEan13;

public class GetProductDetailByEan13QueryHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductDetailByEan13Query, ProductDetailDto>
{
    public async Task<ProductDetailDto> Handle(GetProductDetailByEan13Query request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByEan13Async(request.Ean13, cancellationToken)
                      ?? throw new ProductNotFoundException(request.Ean13);

        return new ProductDetailDto(
            product.Id,
            product.Name,
            product.Description,
            product.Ean13,
            product.Category,
            product.SubCategory,
            product.ManufacturerId,
            product.NutritionFacts,
            product.Ingredients,
            product.Labels,
            product.UserScore,
            product.ExternalScores,
            product.IsHidden);
    }
}