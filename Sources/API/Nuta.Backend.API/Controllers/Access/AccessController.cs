using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nuta.Backend.Access.Application.Commands.RegisterUser;
using Nuta.Backend.Access.Application.Models.Requests;
using Nuta.Backend.Access.Application.Models.Responses;

namespace Nuta.Backend.API.Controllers.Access;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "AccessModuleV1")]
[Route("api/access/v{version:apiVersion}/[controller]")]
public class AccessController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<RegisterUserResponse>> RegisterUserAsync(
        [FromBody] RegisterUserRequest request,
        CancellationToken cancellationToken)
    {
        var userId = await mediator.Send(
            new RegisterUserCommand(request.Email, request.Password, request.Roles),
            cancellationToken);

        return Ok(new RegisterUserResponse(userId));
    }
}