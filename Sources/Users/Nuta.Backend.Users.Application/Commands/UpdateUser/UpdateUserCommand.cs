using MediatR;
using Nuta.Backend.BuildingBlocks.Application.Structs;
using Nuta.Backend.Users.Domain.ValueObjects;

namespace Nuta.Backend.Users.Application.Commands.UpdateUser;

public record UpdateUserCommand(
    Guid UserId,
    Optional<string> Name,
    Optional<FoodPreferences> FoodPreferences)
    : IRequest<Unit>;