using Domain.Base;

namespace Domain.Entities;

public class User : AuditableEntity<Guid>
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }

    public ICollection<Task> Tasks { get; set; }
}
