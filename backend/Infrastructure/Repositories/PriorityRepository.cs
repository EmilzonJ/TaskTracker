using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PriorityRepository(ApplicationDbContext context) : IPriorityRepository
{
    public async Task<List<Priority>> GetAllAsync()
        => await context.Priorities
            .AsNoTracking()
            .ToListAsync();

    public async Task<Priority?> GetByIdAsync(Guid id)
        => await context.Priorities
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
}
