using System.ComponentModel.DataAnnotations;

namespace Repository.Entity;

public record CreditCard
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
}
