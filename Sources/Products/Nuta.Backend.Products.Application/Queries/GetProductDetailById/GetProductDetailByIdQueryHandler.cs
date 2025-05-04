using MediatR;
using Nuta.Backend.Products.Application.Dtos;
using Nuta.Backend.Products.Domain.Exceptions;
using Nuta.Backend.Products.Domain.Repositories;

namespace Nuta.Backend.Products.Application.Queries.GetProductDetailById;

public class GetProductDetailByIdQueryHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductDetailByIdQuery, ProductDetailDto>
{
    public async Task<ProductDetailDto> Handle(GetProductDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId, cancellationToken)
                      ?? throw new ProductNotFoundException(request.ProductId);

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