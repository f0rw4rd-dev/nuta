using MediatR;
using Nuta.Backend.Products.Application.Dtos;
using Nuta.Backend.Products.Application.Services.Interfaces;
using Nuta.Backend.Products.Domain.Repositories;

namespace Nuta.Backend.Products.Application.Queries.GetProductShortInfoList;

public class GetProductShortInfoListQueryHandler(
    IProductRepository productRepository,
    IProductAssessmentService productAssessmentService)
    : IRequestHandler<GetProductShortInfoListQuery, IReadOnlyCollection<ProductShortInfoDto>>
{
    public async Task<IReadOnlyCollection<ProductShortInfoDto>> Handle(
        GetProductShortInfoListQuery request,
        CancellationToken cancellationToken)
    {
        var products = await productRepository.GetListAsync(
            request.ProductIds,
            cancellationToken);

        var nutaScores = new int[products.Count];
        var nutaScoreIndex = 0;

        foreach (var product in products)
            nutaScores[nutaScoreIndex++] = await productAssessmentService.CalculateNutaScoreAsync(
                product,
                cancellationToken);

        return products
            .Select((x, index) => new ProductShortInfoDto(
                x.Id,
                x.Name,
                x.Manufacturer.Name,
                x.UserScore,
                nutaScores[index]))
            .ToArray();
    }
}