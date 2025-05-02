using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nuta.Backend.Users.Application.Dtos;
using Nuta.Backend.Users.Application.Queries.GetUserViewedProductList;

namespace Nuta.Backend.API.Controllers.Users;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "UsersModuleV1")]
[Route("api/users/v{version:apiVersion}/[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet("viewed-products")]
    public async Task<ActionResult<IReadOnlyCollection<UserProductViewDto>>> GetUserViewedProductListAsync(
        Guid userId,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(
            new GetUserViewedProductListQuery(userId),
            cancellationToken);

        return Ok(result);
    }
}