using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Products.Application.Commands.CreateAdditive;
using Nuta.Backend.Products.Application.Commands.UpdateAdditive;
using Nuta.Backend.Products.Application.Dtos;
using Nuta.Backend.Products.Application.Models.Requests;
using Nuta.Backend.Products.Application.Models.Responses;
using Nuta.Backend.Products.Application.Queries.GetAdditive;
using Nuta.Backend.Products.Application.Queries.GetAdditives;

namespace Nuta.Backend.API.Controllers.Products;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "ProductsModuleV1")]
[Route("api/products/v{version:apiVersion}/[controller]")]
public class AdditivesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{additiveId:guid}")]
    public async Task<ActionResult<AdditiveDto>> GetAdditiveAsync(
        [FromRoute] Guid additiveId,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAdditiveQuery(additiveId), cancellationToken);

        return Ok(result);
    }

    [HttpGet("")]
    public async Task<ActionResult<AdditiveDto>> GetAdditivesAsync(
        [FromQuery] Pagination pagination,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAdditivesQuery(pagination), cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CreateAdditiveResponse>> CreateAdditiveAsync(
        [FromBody] CreateAdditiveRequest request,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(
            new CreateAdditiveCommand(
                request.Name,
                request.ChemicalName,
                request.ENumber,
                request.Description,
                request.RiskLevel),
            cancellationToken);

        return Ok(result);
    }

    [HttpPut("{additiveId:guid}")]
    public async Task<IActionResult> UpdateAdditiveAsync(
        [FromRoute] Guid additiveId,
        [FromBody] UpdateAdditiveRequest request,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(
            new UpdateAdditiveCommand(
                additiveId,
                request.Name,
                request.ChemicalName,
                request.ENumber,
                request.Description,
                request.RiskLevel),
            cancellationToken);

        return Ok(result);
    }
}