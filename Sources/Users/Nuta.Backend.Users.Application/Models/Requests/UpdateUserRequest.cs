using Nuta.Backend.Users.Domain.ValueObjects;

namespace Nuta.Backend.Users.Application.Models.Requests;

public record UpdateUserRequest(string? Name, FoodPreferences? FoodPreferences);