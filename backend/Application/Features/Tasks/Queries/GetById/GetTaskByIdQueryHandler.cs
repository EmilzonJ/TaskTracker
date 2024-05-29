using Application.Exceptions;
using Application.Features.Priorities.Queries.GetAll;
using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetTasks;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Tasks.Queries.GetById;

public record GetTaskByIdQueryHandler(
    ITaskRepository TaskRepository
) : IRequestHandler<GetTaskByIdQuery, TaskResponse>
{
    public async Task<TaskResponse> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await TaskRepository.GetByIdAsync(request.Id);

        if (task is null) throw new NotFoundException("Tarea no encontrada.");

        return new TaskResponse(
            task.Id,
            task.Title,
            task.Description,
            task.Tags.Split(',').ToList(),
            task.ExpirationDate,
            task.Finished,
            new UserResponse(
                task.User.Id,
                task.User.Name,
                task.User.Surname,
                task.User.Email,
                task.User.Phone
            ),
            new PriorityResponse(
                task.Priority.Id,
                task.Priority.Name
            ),
            task.CreatedAt
        );
    }
}
