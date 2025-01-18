namespace Repository.Entity;

public record User
{
    public Guid Id { get; init; }
    public string Email { get; init; }
    public string Password { get; set; }
}
