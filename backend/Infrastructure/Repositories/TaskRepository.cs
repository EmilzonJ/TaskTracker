using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using TaskEntity = Domain.Entities.Task;

namespace Infrastructure.Repositories;

public class TaskRepository(ApplicationDbContext context) : ITaskRepository
{
    public async Task<List<TaskEntity>> GetAllAsync()
        => await context.Tasks
            .AsNoTracking()
            .Include(t => t.User)
            .Include(t => t.Priority)
            .ToListAsync();

    public async Task<TaskEntity?> GetByIdAsync(Guid id)
        => await context.Tasks
            .Include(t => t.User)
            .Include(t => t.Priority)
            .FirstOrDefaultAsync(t => t.Id == id);

    public async Task<TaskEntity> AddAsync(TaskEntity task)
    {
        await context.Tasks.AddAsync(task);
        await context.SaveChangesAsync();

        return task;
    }

    public async Task<TaskEntity> UpdateAsync(TaskEntity task)
    {
        context.Tasks.Update(task);
        await context.SaveChangesAsync();

        return task;
    }

    public async Task DeleteAsync(TaskEntity task)
    {
        task.IsDeleted = true;
        task.DeletedAt = DateTime.UtcNow;

        context.Tasks.Update(task);
        await context.SaveChangesAsync();
    }
}
