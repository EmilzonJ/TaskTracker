using Application.Features.Users.Queries.GetTasks;
using MediatR;

namespace Application.Features.Tasks.Queries.GetAll;

public record GetAllTasksQuery : IRequest<List<TaskResponse>>;
