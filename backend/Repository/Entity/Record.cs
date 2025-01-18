using System.ComponentModel.DataAnnotations;

namespace Repository.Entity;

public record Record
{
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();

    public string Name { get; set; }
}
