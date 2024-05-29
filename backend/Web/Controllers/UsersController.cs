using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetTasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Attributes;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiKey]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<List<UserResponse>> GetAsync()
        => await mediator.Send(new GetAllUsersQuery());

    [HttpGet("{id:guid}")]
    public async Task<UserResponse> GetAsync(Guid id)
        => await mediator.Send(new GetUserByIdQuery(id));

    [HttpGet("{id:guid}/tasks")]
    public async Task<List<TaskResponse>> GetTasksAsync(Guid id)
        => await mediator.Send(new GetUserTasksQuery(id));

    [HttpPost]
    public async Task<Guid> PostAsync(CreateUserCommand command)
        => await mediator.Send(command);

    [HttpDelete]
    public async Task DeleteAsync(Guid id)
        => await mediator.Send(new DeleteUserCommand(id));

}
