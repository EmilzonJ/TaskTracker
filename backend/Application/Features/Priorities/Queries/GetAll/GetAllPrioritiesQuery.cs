using MediatR;

namespace Application.Features.Priorities.Queries.GetAll;

public record GetAllPrioritiesQuery : IRequest<List<PriorityResponse>>;

public record PriorityResponse(
    Guid Id,
    string Name
);
