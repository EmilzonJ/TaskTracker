using MediatR;

namespace Application.Features.Tasks.Commands.Delete;

public record DeleteTaskCommand(Guid Id) : IRequest;
