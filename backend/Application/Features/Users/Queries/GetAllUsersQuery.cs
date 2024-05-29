using MediatR;

namespace Application.Features.Users.Queries;

public class GetAllUsersQuery : IRequest<List<UserResponse>>;

public record UserResponse(
    Guid Id,
    string Name,
    string Surname,
    string Email,
    string Phone
);
