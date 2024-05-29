using Application.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Tasks.Commands.Update;

public class UpdateTaskCommandHandler(
    ITaskRepository taskRepository,
    IPriorityRepository priorityRepository
) : IRequestHandler<UpdateTaskCommand>
{
    public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var priority = await priorityRepository.GetByIdAsync(request.PriorityId);
        if(priority is null) throw new NotFoundException("Prioridad no encontrada");

        var task = await taskRepository.GetByIdAsync(request.Id);
        if(task is null) throw new NotFoundException("Tarea no encontrada");

        task.Title = request.Title;
        task.Description = request.Description;
        task.Tags = string.Join(",", request.Tags);
        task.ExpirationDate = request.ExpirationDate;
        task.Finished = request.Finished;
        task.PriorityId = request.PriorityId;

        await taskRepository.UpdateAsync(task);
    }
}
