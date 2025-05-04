using Nuta.Backend.Users.Domain.ValueObjects;

namespace Nuta.Backend.Users.Application.Dtos;

public record UserDto(Guid Id, string Name, FoodPreferences FoodPreferences);