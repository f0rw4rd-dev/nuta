using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nuta.Backend.Access.Domain.Constants;
using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Products.Application.Commands.CreateManufacturer;
using Nuta.Backend.Products.Application.Commands.UpdateManufacturer;
using Nuta.Backend.Products.Application.Dtos;
using Nuta.Backend.Products.Application.Models.Requests;
using Nuta.Backend.Products.Application.Models.Responses;
using Nuta.Backend.Products.Application.Queries.GetManufacturer;
using Nuta.Backend.Products.Application.Queries.GetManufacturers;

namespace Nuta.Backend.API.Controllers.Products;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "ProductsModuleV1")]
[Route("api/products/v{version:apiVersion}/[controller]")]
public class ManufacturersController(IMediator mediator) : ControllerBase
{
    [HttpGet("{manufacturerId:guid}")]
    public async Task<ActionResult<ManufacturerDto>> GetManufacturerAsync(
        [FromRoute] Guid manufacturerId,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetManufacturerQuery(manufacturerId), cancellationToken);

        return Ok(result);
    }

    [HttpGet("")]
    public async Task<ActionResult<ManufacturerDto>> GetManufacturersAsync(
        [FromQuery] Pagination pagination,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetManufacturersQuery(pagination), cancellationToken);

        return Ok(result);
    }

    [Authorize(Roles = RoleConstants.Moderator)]
    [HttpPost]
    public async Task<ActionResult<CreateManufacturerResponse>> CreateManufacturerAsync(
        [FromBody] CreateManufacturerRequest request,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(
            new CreateManufacturerCommand(
                request.Name,
                request.Description),
            cancellationToken);

        return Ok(result);
    }

    [Authorize(Roles = RoleConstants.Moderator)]
    [HttpPut("{manufacturerId:guid}")]
    public async Task<IActionResult> UpdateManufacturerAsync(
        [FromRoute] Guid manufacturerId,
        [FromBody] UpdateManufacturerRequest request,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(
            new UpdateManufacturerCommand(
                manufacturerId,
                request.Name,
                request.Description),
            cancellationToken);

        return Ok(result);
    }
}