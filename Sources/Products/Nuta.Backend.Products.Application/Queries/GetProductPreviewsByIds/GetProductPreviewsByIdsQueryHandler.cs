using MediatR;
using Nuta.Backend.Products.Application.Dtos;
using Nuta.Backend.Products.Application.Services.Interfaces;
using Nuta.Backend.Products.Domain.Repositories;

namespace Nuta.Backend.Products.Application.Queries.GetProductPreviewsByIds;

public class GetProductPreviewsByIdsQueryHandler(
    IProductRepository productRepository,
    IProductAssessmentService productAssessmentService)
    : IRequestHandler<GetProductPreviewsByIdsQuery, IReadOnlyCollection<ProductPreviewDto>>
{
    public async Task<IReadOnlyCollection<ProductPreviewDto>> Handle(
        GetProductPreviewsByIdsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await productRepository.GetListByIdsAsync(
            request.ProductIds,
            request.Pagination,
            cancellationToken);

        var nutaScores = new int[products.Count];
        var nutaScoreIndex = 0;

        foreach (var product in products)
            nutaScores[nutaScoreIndex++] = await productAssessmentService.CalculateNutaScoreAsync(
                product,
                cancellationToken);

        var result = products
            .Select((product, index) => new ProductPreviewDto(
                product.Id,
                product.Name,
                product.Manufacturer.Name,
                product.UserScore,
                nutaScores[index],
                product.IsHidden))
            .ToArray();

        return result;
    }
}