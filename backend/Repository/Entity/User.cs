using System.ComponentModel.DataAnnotations;

namespace Repository.Entity;

public record User
{
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Email { get; init; }
    public string Password { get; set; }
    public virtual ICollection<Account> Accounts { get; set; }
}
