using MediatR;
using Nuta.Backend.Users.Domain.ValueObjects;

namespace Nuta.Backend.Users.Application.Commands.UpdateUser;

public record UpdateUserCommand(Guid UserId, string? Name, FoodPreferences? FoodPreferences) : IRequest<Unit>;