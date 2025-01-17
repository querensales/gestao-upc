namespace Repository.Entity;

public class User
{
    public Guid Id { get; init; }
    public string Email { get; set; }
    public string Password { get; set; }
}
