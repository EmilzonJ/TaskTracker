using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;
using TaskEntity = Domain.Entities.Task;

namespace Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<List<User>> GetAllAsync()
        => await context.Users.AsNoTracking().ToListAsync();

    public async Task<User?> GetByIdAsync(Guid id)
        => await context.Users.FirstOrDefaultAsync(u => u.Id == id);

    public async Task<List<TaskEntity>> GetTasksAsync(Guid id)
        => await context.Tasks
            .Include(t => t.User)
            .Include(t => t.Priority)
            .Where(t => t.UserId == id)
            .ToListAsync();

    public async Task<User> AddAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return user;
    }

    public async Task<bool> ExistsByEmailAsync(string email)
        => await context.Users.AnyAsync(u => u.Email == email);

    public async Task DeleteAsync(User user)
    {
        user.DeletedAt = DateTime.UtcNow;
        user.IsDeleted = true;

        context.Users.Update(user);
        await context.SaveChangesAsync();
    }
}
