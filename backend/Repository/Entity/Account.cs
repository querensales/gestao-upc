namespace Repository.Entity;

public record Account
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string Name { get; set; }

    public bool Active { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}
