using Domain.Base;

namespace Domain.Entities;

public class Priority : Entity<Guid>
{
    public required string Name { get; set; }
}
