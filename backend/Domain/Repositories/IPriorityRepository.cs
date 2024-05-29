using Domain.Entities;

namespace Domain.Repositories;

public interface IPriorityRepository
{
    Task<List<Priority>> GetAllAsync();
    Task<Priority?> GetByIdAsync(Guid id);
}
