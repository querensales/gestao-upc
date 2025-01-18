namespace Repository.Entity;

public record Account
{
    public Guid Id { get; init; }

    public string Name { get; set; }

    public bool Active { get; set; }
}
