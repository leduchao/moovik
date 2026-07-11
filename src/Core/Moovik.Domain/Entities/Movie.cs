namespace Moovik.Domain.Entities;

public class Movie : AuditEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int AmountOfTime { get; set; } // minutes
    public DateTime ReleaseDate { get; set; }
}
