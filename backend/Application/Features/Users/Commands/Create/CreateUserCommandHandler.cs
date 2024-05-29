using Application.Exceptions;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Users.Commands.Create;

public record CreateUserCommandHandler(
    IUserRepository UserRepository
) : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await UserRepository.ExistsByEmailAsync(request.Email))
            throw new UnprocessableEntityException("Usuario con el mismo email ya existe");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            Name = request.Name,
            Surname = request.Surname,
            Phone = request.Phone
        };

        await UserRepository.AddAsync(user);

        return user.Id;
    }
}
