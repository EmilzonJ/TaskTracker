using Application.Exceptions;
using Domain.Repositories;
using MediatR;
using TaskEntity = Domain.Entities.Task;

namespace Application.Features.Tasks.Commands.Create;

public record CreateTaskCommandHandler(
    ITaskRepository TaskRepository,
    IUserRepository UserRepository,
    IPriorityRepository PriorityRepository
) : IRequestHandler<CreateTaskCommand, Guid>
{
    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var user = await UserRepository.GetByIdAsync(request.UserId);
        if(user is null) throw new NotFoundException("Usuario no encontrado");

        var priority = await PriorityRepository.GetByIdAsync(request.PriorityId);
        if(priority is null) throw new NotFoundException("Prioridad no encontrada");

        var task = new TaskEntity
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Tags = string.Join(",", request.Tags),
            ExpirationDate = request.ExpirationDate,
            Finished = false,
            UserId = request.UserId,
            PriorityId = request.PriorityId
        };

        await TaskRepository.AddAsync(task);

        return task.Id;
    }
}
