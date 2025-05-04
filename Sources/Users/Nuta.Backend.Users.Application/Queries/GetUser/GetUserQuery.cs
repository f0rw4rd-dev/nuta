using MediatR;
using Nuta.Backend.Users.Application.Dtos;

namespace Nuta.Backend.Users.Application.Queries.GetUser;

public record GetUserQuery(Guid UserId) : IRequest<UserDto>;