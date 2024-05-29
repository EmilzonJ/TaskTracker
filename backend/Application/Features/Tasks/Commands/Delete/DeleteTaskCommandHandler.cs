using Application.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Tasks.Commands.Delete;

public record DeleteTaskCommandHandler(
    ITaskRepository TaskRepository
) : IRequestHandler<DeleteTaskCommand>
{
    public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await TaskRepository.GetByIdAsync(request.Id);

        if (task is null)
            throw new NotFoundException("Tarea no encontrada");

        await TaskRepository.DeleteAsync(task);
    }
}
