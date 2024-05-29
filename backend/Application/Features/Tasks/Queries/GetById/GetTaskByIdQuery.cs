using Application.Features.Users.Queries.GetTasks;
using MediatR;

namespace Application.Features.Tasks.Queries.GetById;

public record GetTaskByIdQuery(Guid Id) : IRequest<TaskResponse>;
