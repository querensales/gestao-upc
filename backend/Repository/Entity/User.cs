using System.ComponentModel.DataAnnotations;

namespace Repository.Entity;

public record User
{
    [Key]
    public Guid Id { get; init; }
    public string Email { get; init; }
    public string Password { get; set; }
}
