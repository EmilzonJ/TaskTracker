using Application.Features.Users.Queries;
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
    public async Task<List<UserResponse>> GetAll()
    {
        return await mediator.Send(new GetAllUsersQuery());
    }
}
