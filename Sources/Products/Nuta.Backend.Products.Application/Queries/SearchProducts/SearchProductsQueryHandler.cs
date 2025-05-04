using MediatR;
using Nuta.Backend.Products.Application.Dtos;
using Nuta.Backend.Products.Application.Services.Interfaces;

namespace Nuta.Backend.Products.Application.Queries.SearchProducts;

public class SearchProductsQueryHandler(
    IProductSearchService productSearchService,
    IProductAssessmentService productAssessmentService)
    : IRequestHandler<SearchProductsQuery, IReadOnlyCollection<ProductPreviewDto>>
{
    public async Task<IReadOnlyCollection<ProductPreviewDto>> Handle(SearchProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await productSearchService.SearchAsync(
            request.Term,
            request.SortBy,
            request.Filter,
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