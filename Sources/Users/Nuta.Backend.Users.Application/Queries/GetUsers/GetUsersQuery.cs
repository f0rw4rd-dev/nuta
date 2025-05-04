using MediatR;
using Nuta.Backend.BuildingBlocks.Application.Models;
using Nuta.Backend.Users.Application.Dtos;

namespace Nuta.Backend.Users.Application.Queries.GetUsers;

public record GetUsersQuery(Pagination Pagination) : IRequest<IReadOnlyCollection<UserDto>>;