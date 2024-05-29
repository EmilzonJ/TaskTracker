using Application.Features.Users.Queries.GetAll;
using MediatR;

namespace Application.Features.Users.Queries.GetTasks;

public record GetUserTasksQuery(Guid UserId) : IRequest<List<TaskResponse>>;

public record TaskResponse(
    Guid Id,
    string Title,
    string Description,
    List<string> Tags,
    DateTime ExpirationDate,
    bool Finished,
    UserResponse User,
    string Priority,
    DateTime CreatedAt
);
