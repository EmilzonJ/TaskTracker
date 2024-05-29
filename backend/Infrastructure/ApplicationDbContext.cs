using Domain.Base;
using Domain.Entities;
using Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;
using TaskEntity = Domain.Entities.Task;

namespace Infrastructure;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public async Task<int> SaveChangesAsync()
    {
        OnBeforeSaving();
        return await base.SaveChangesAsync();
    }

    private void OnBeforeSaving()
    {
        var utcNow = DateTime.UtcNow;
        ChangeTracker.DetectChanges();

        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
        {
            if (entry.State is EntityState.Detached or EntityState.Unchanged or EntityState.Deleted)
                continue;

            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = utcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = utcNow;
                    break;
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SeedPriorities();

        modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
        modelBuilder.Entity<TaskEntity>().HasQueryFilter(t => !t.IsDeleted);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<Priority> Priorities { get; set; }
}
