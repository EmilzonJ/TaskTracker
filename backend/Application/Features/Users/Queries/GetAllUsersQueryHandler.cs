using Domain.Repositories;
using MediatR;

namespace Application.Features.Users.Queries;

public record GetAllUsersQueryHandler(
    IUserRepository UserRepository
) : IRequestHandler<GetAllUsersQuery, List<UserResponse>>
{
    public async Task<List<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await UserRepository.GetAllAsync();

        return users.Select(u => new UserResponse(u.Id, u.Name, u.Surname, u.Email, u.Phone)).ToList();
    }
}
