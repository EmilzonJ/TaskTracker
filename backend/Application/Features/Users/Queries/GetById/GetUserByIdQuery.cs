using Application.Features.Users.Queries.GetAll;
using MediatR;

namespace Application.Features.Users.Queries.GetById;

public record GetUserByIdQuery(Guid Id) : IRequest<UserResponse>;
