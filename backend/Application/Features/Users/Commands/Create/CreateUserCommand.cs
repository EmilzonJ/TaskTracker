using MediatR;

namespace Application.Features.Users.Commands.Create;

public record CreateUserCommand(
    string Name,
    string Surname,
    string Email,
    string Phone
) : IRequest<Guid>;
