using Application.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Users.Commands.Delete;

public record DeleteUserCommandHandler(
    IUserRepository UserRepository
) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await UserRepository.GetByIdAsync(request.Id);

        if (user is null)
            throw new NotFoundException("Usuario no encontrado");

        await UserRepository.DeleteAsync(user);
    }
}
