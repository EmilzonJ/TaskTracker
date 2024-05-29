using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seeds;

public static class PrioritySeed
{
    public static ModelBuilder SeedPriorities(this ModelBuilder modelBuilder)
    {
        List<Priority> priorities =
        [
            new Priority {Id = Guid.Parse("3f0ece66-0cb7-49b2-a3c4-8b8a4733964f"), Name = "Alta"},
            new Priority {Id = Guid.Parse("ba44a2e3-bc30-46a0-9285-71180929ada7"), Name = "Media"},
            new Priority {Id = Guid.Parse("19103700-c018-464f-9c64-4a4bd6924fdf"), Name = "Baja"}
        ];

        modelBuilder.Entity<Priority>().HasData(priorities);

        return modelBuilder;
    }
}
