using Nuta.Backend.Users.Application.Dtos;

namespace Nuta.Backend.Users.Application.Models.Responses;

public record GetUsersResponse(IReadOnlyCollection<UserDto> Users);