namespace Domain.Base;

public interface IAuditableEntity
{
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
    DateTime? DeletedAt { get; set; }
    bool IsDeleted { get; set; }
}

public interface IAuditableEntity<out TPKey> : IAuditableEntity
{
    TPKey Id { get; }
}

public abstract class AuditableEntity<TPKey> : IAuditableEntity<TPKey>
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
    public required TPKey Id { get; set; }
}

public abstract class Entity<TPKey>
{
    public required TPKey Id { get; set; }
}

