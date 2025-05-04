using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Products.Application.Commands.CreateProduct;
using Nuta.Backend.Products.Application.Commands.UpdateProduct;
using Nuta.Backend.Products.Application.Models.Requests;
using Nuta.Backend.Products.Application.Models.Responses;
using Nuta.Backend.Products.Application.Queries.GetProductDetailByEan13;
using Nuta.Backend.Products.Application.Queries.GetProductDetailById;
using Nuta.Backend.Products.Application.Queries.GetProductPreviewsByIds;
using Nuta.Backend.Products.Application.Queries.SearchProducts;

namespace Nuta.Backend.API.Controllers.Products;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "ProductsModuleV1")]
[Route("api/products/v{version:apiVersion}/[controller]")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpGet("previews")]
    public async Task<ActionResult<GetProductPreviewsByIdsResponse>> GetProductPreviewsByIdsAsync(
        [FromQuery] IReadOnlyCollection<Guid> productIds,
        [FromQuery] Pagination pagination,
        CancellationToken cancellationToken)
    {
        var dtos = await mediator.Send(
            new GetProductPreviewsByIdsQuery(productIds, pagination),
            cancellationToken);

        return Ok(new GetProductPreviewsByIdsResponse(dtos));
    }

    [HttpGet("{productId:guid}")]
    public async Task<ActionResult<GetProductDetailByIdResponse>> GetProductDetailByIdAsync(
        [FromRoute] Guid productId,
        CancellationToken cancellationToken)
    {
        var dto = await mediator.Send(
            new GetProductDetailByIdQuery(productId),
            cancellationToken);

        return Ok(new GetProductDetailByIdResponse(dto));
    }

    [HttpGet("{ean13:length(13)}")]
    public async Task<ActionResult<GetProductDetailByIdResponse>> GetProductDetailByEan13Async(
        [FromRoute] string ean13,
        CancellationToken cancellationToken)
    {
        var dto = await mediator.Send(
            new GetProductDetailByEan13Query(ean13),
            cancellationToken);

        return Ok(new GetProductDetailByEan13Response(dto));
    }

    [HttpGet]
    public async Task<ActionResult<SearchProductsResponse>> SearchProductsAsync(
        [FromQuery] SearchProductsRequest request,
        CancellationToken cancellationToken)
    {
        var dtos = await mediator.Send(
            new SearchProductsQuery(request.Term, request.SortBy, request.Filter, request.Pagination),
            cancellationToken);

        return Ok(new SearchProductsResponse(dtos));
    }

    [HttpPost]
    public async Task<ActionResult<SearchProductsResponse>> CreateProductAsync(
        [FromBody] CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        var productId = await mediator.Send(
            new CreateProductCommand(
                request.Name,
                request.Description,
                request.Ean13,
                request.ImageKey,
                request.Category,
                request.SubCategory,
                request.ManufacturerId,
                request.NutritionFacts,
                request.Ingredients,
                request.Labels,
                request.ExternalScores),
            cancellationToken);

        return Ok(new CreateProductResponse(productId));
    }

    [HttpPut("{productId:guid}")]
    public async Task<ActionResult<SearchProductsResponse>> UpdateProductAsync(
        [FromRoute] Guid productId,
        [FromBody] UpdateProductRequest request,
        CancellationToken cancellationToken)
    {
        await mediator.Send(
            new UpdateProductCommand(
                productId,
                request.Name,
                request.Description,
                request.Ean13,
                request.ImageKey,
                request.Category,
                request.SubCategory,
                request.ManufacturerId,
                request.NutritionFacts,
                request.Ingredients,
                request.Labels,
                request.ExternalScores),
            cancellationToken);

        return Ok();
    }
}