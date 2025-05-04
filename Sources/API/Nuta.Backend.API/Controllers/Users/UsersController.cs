using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Users.Application.Commands.AddUserFavoriteProduct;
using Nuta.Backend.Users.Application.Commands.CreateUser;
using Nuta.Backend.Users.Application.Commands.RemoveUserFavoriteProduct;
using Nuta.Backend.Users.Application.Commands.UpdateUser;
using Nuta.Backend.Users.Application.Models.Requests;
using Nuta.Backend.Users.Application.Models.Responses;
using Nuta.Backend.Users.Application.Queries.GetUser;
using Nuta.Backend.Users.Application.Queries.GetUserFavoriteProducts;
using Nuta.Backend.Users.Application.Queries.GetUsers;
using Nuta.Backend.Users.Application.Queries.GetUserViewedProducts;

namespace Nuta.Backend.API.Controllers.Users;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "UsersModuleV1")]
[Route("api/users/v{version:apiVersion}/[controller]")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet("{userId:guid}/viewed-products")]
    public async Task<ActionResult<GetUserViewedProductsResponse>> GetUserViewedProductsAsync(
        [FromRoute] Guid userId,
        [FromQuery] Pagination pagination,
        CancellationToken cancellationToken)
    {
        var dtos = await mediator.Send(
            new GetUserViewedProductsQuery(userId, pagination),
            cancellationToken);

        return Ok(new GetUserViewedProductsResponse(dtos));
    }

    [HttpGet("{userId:guid}/favorite-products")]
    public async Task<ActionResult<GetUserFavoriteProductsResponse>> GetUserFavoriteProductsAsync(
        [FromRoute] Guid userId,
        [FromQuery] Pagination pagination,
        CancellationToken cancellationToken)
    {
        var dtos = await mediator.Send(
            new GetUserFavoriteProductsQuery(userId, pagination),
            cancellationToken);

        return Ok(new GetUserFavoriteProductsResponse(dtos));
    }

    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<GetUserResponse>> GetUserAsync(
        [FromRoute] Guid userId,
        CancellationToken cancellationToken)
    {
        var dto = await mediator.Send(new GetUserQuery(userId), cancellationToken);

        return Ok(new GetUserResponse(dto));
    }

    [HttpGet]
    public async Task<ActionResult<GetUsersResponse>> GetUsersAsync(
        [FromQuery] Pagination pagination,
        CancellationToken cancellationToken)
    {
        var dtos = await mediator.Send(new GetUsersQuery(pagination), cancellationToken);

        return Ok(new GetUsersResponse(dtos));
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserResponse>> CreateUserAsync(
        [FromBody] CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var userId = await mediator.Send(new CreateUserCommand(request.Name), cancellationToken);

        return StatusCode(StatusCodes.Status201Created, new CreateUserResponse(userId));
    }

    [HttpPost("{userId:guid}/favorite-products/{productId:guid}")]
    public async Task<IActionResult> AddUserFavoriteProductAsync(
        [FromRoute] Guid userId,
        [FromRoute] Guid productId,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new AddUserFavoriteProductCommand(userId, productId), cancellationToken);

        return Ok();
    }

    [HttpDelete("{userId:guid}/favorite-products/{productId:guid}")]
    public async Task<IActionResult> RemoveUserFavoriteProductAsync(
        [FromRoute] Guid userId,
        [FromRoute] Guid productId,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new RemoveUserFavoriteProductCommand(userId, productId), cancellationToken);

        return Ok();
    }

    [HttpPatch("{userId:guid}")]
    public async Task<IActionResult> UpdateUserAsync(
        [FromRoute] Guid userId,
        [FromBody] UpdateUserRequest request,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new UpdateUserCommand(userId, request.Name, request.FoodPreferences), cancellationToken);

        return Ok();
    }
}