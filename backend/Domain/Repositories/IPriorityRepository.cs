using Domain.Entities;

namespace Domain.Repositories;

public interface IPriorityRepository
{
    Task<List<Priority>> GetAllAsync();
}
