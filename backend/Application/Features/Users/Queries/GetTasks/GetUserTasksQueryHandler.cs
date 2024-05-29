using Application.Features.Priorities.Queries.GetAll;
using Application.Features.Users.Queries.GetAll;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Users.Queries.GetTasks;

public record GetUserTasksQueryHandler(
    IUserRepository UserRepository
) : IRequestHandler<GetUserTasksQuery, List<TaskResponse>>
{
    public async Task<List<TaskResponse>> Handle(GetUserTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await UserRepository.GetTasksAsync(request.UserId);

        return tasks.Select(t => new TaskResponse(
            t.Id,
            t.Title,
            t.Description,
            t.Tags.Split(',').ToList(),
            t.ExpirationDate,
            t.Finished,
            new UserResponse(t.User.Id, t.User.Name, t.User.Surname, t.User.Email, t.User.Phone),
            new PriorityResponse(t.Priority.Id, t.Priority.Name),
            t.CreatedAt
        )).ToList();
    }
}
