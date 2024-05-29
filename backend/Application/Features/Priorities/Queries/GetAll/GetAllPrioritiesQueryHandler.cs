using Domain.Repositories;
using MediatR;

namespace Application.Features.Priorities.Queries.GetAll;

public record GetAllPrioritiesQueryHandler(
    IPriorityRepository PriorityRepository
) : IRequestHandler<GetAllPrioritiesQuery, List<PriorityResponse>>
{
    public async Task<List<PriorityResponse>> Handle(GetAllPrioritiesQuery request, CancellationToken cancellationToken)
    {
        var priorities = await PriorityRepository.GetAllAsync();

        return priorities.Select(p => new PriorityResponse(p.Id, p.Name)).ToList();
    }
}
