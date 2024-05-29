using MediatR;

namespace Application.Features.Tasks.Commands.Create;

public record CreateTaskCommand(
    string Title,
    string Description,
    IEnumerable<string> Tags,
    DateTime ExpirationDate,
    Guid UserId,
    Guid PriorityId
) : IRequest<Guid>;
