using Application.Features.Priorities.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Attributes;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiKey]
public class PrioritiesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<List<PriorityResponse>> GetAsync()
        => await mediator.Send(new GetAllPrioritiesQuery());
}
