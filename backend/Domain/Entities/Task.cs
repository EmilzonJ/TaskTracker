using Domain.Base;

namespace Domain.Entities;

public class Task : AuditableEntity<Guid>
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Tags { get; set; }
    public required DateTime ExpirationDate { get; set; }
    public required bool Finished { get; set; }

    public required Guid UserId { get; set; }
    public User User { get; set; }

    public required Guid PriorityId { get; set; }
    public Priority Priority { get; set; }
}
