using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nuta.Backend.Products.Application.Dtos;
using Nuta.Backend.Products.Application.Queries.GetProductsShortInfo;

namespace Nuta.Backend.API.Controllers.Products;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "ProductsModuleV1")]
[Route("api/products/v{version:apiVersion}/[controller]")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpGet("short-info")]
    public async Task<ActionResult<IReadOnlyCollection<ProductShortInfoDto>>> GetProductShortInfoListAsync(
        IReadOnlyCollection<Guid> productIds,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(
            new GetProductsShortInfoQuery(productIds),
            cancellationToken);

        return Ok(result);
    }
}