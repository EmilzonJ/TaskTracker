using MediatR;

namespace Application.Features.Tasks.Commands.Update;

public record UpdateTaskCommand(
    Guid Id,
    string Title,
    string Description,
    IEnumerable<string> Tags,
    DateTime ExpirationDate,
    bool Finished,
    Guid PriorityId
) : IRequest;

public record UpdateTaskRequest(
    string Title,
    string Description,
    IEnumerable<string> Tags,
    DateTime ExpirationDate,
    bool Finished,
    Guid PriorityId
);
