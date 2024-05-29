using Domain.Entities;
using Task = System.Threading.Tasks.Task;
using TaskEntity = Domain.Entities.Task;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid id);
    Task<User> AddAsync(User user);
    Task<bool> ExistsByEmailAsync(string email);
    Task DeleteAsync(User user);
    Task<List<TaskEntity>> GetTasksAsync(Guid id);
}
