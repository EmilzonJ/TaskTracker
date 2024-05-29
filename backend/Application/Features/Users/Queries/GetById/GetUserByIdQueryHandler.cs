using Application.Exceptions;
using Application.Features.Users.Queries.GetAll;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Users.Queries.GetById;

public record GetUserByIdQueryHandler(
    IUserRepository UserRepository
) : IRequestHandler<GetUserByIdQuery, UserResponse>
{
    public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await UserRepository.GetByIdAsync(request.Id);

        if (user is null) throw new NotFoundException("Usuario no encontrado");

        return new UserResponse(user.Id, user.Name, user.Surname, user.Email, user.Phone);
    }
}
