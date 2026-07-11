namespace Moovik.Domain.Entities;

public class BaseEntity
{
    public int Id { get; init; }
    public Guid EntityId { get; init; } = Guid.NewGuid();
}