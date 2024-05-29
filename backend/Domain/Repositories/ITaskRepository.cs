namespace Domain.Repositories;
using TaskEntity = Domain.Entities.Task;

public interface ITaskRepository
{
    Task<List<TaskEntity>> GetAllAsync();
    Task<TaskEntity?> GetByIdAsync(Guid id);
    Task<TaskEntity> AddAsync(TaskEntity task);
    Task<TaskEntity> UpdateAsync(TaskEntity task);
    Task DeleteAsync(TaskEntity task);
}
