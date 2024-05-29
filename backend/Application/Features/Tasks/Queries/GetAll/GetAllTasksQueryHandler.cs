using Application.Features.Priorities.Queries.GetAll;
using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetTasks;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Tasks.Queries.GetAll;

public record GetAllTasksQueryHandler(
    ITaskRepository TaskRepository
) : IRequestHandler<GetAllTasksQuery, List<TaskResponse>>
{
    public async Task<List<TaskResponse>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await TaskRepository.GetAllAsync();

        return tasks.Select(t => new TaskResponse(
            t.Id,
            t.Title,
            t.Description,
            t.Tags.Split(',').ToList(),
            t.ExpirationDate,
            t.Finished,
            new UserResponse(
                t.User.Id,
                t.User.Name,
                t.User.Surname,
                t.User.Email,
                t.User.Phone
            ),
            new PriorityResponse(
                t.Priority.Id,
                t.Priority.Name
            ),
            t.CreatedAt
        )).ToList();
    }
}
