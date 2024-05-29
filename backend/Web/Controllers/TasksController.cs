using Application.Features.Tasks.Commands.Create;
using Application.Features.Tasks.Commands.Delete;
using Application.Features.Tasks.Commands.Update;
using Application.Features.Tasks.Queries.GetAll;
using Application.Features.Tasks.Queries.GetById;
using Application.Features.Users.Queries.GetTasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Attributes;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiKey]
public class TasksController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<List<TaskResponse>> GetAsync()
        => await mediator.Send(new GetAllTasksQuery());

    [HttpGet("{id:guid}")]
    public async Task<TaskResponse> GetAsync(Guid id)
        => await mediator.Send(new GetTaskByIdQuery(id));

    [HttpPost]
    public async Task<Guid> PostAsync(CreateTaskCommand command)
        => await mediator.Send(command);

    [HttpPut("{id:guid}")]
    public async Task PutAsync(Guid id, UpdateTaskRequest request)
    {
        var command = new UpdateTaskCommand(
            id,
            request.Title,
            request.Description,
            request.Tags,
            request.ExpirationDate,
            request.Finished,
            request.PriorityId
        );

        await mediator.Send(command);
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteAsync(Guid id)
    {
        var command = new DeleteTaskCommand(id);

        await mediator.Send(command);
    }
}
