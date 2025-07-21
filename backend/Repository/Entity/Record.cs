using System.ComponentModel.DataAnnotations;

namespace Repository.Entity;

public record Record
{
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();

    public string Name { get; set; }
    public Guid SubCategoryId { get; set; }
    public virtual SubCategory SubCategory { get; set; }

    public Guid AccountId { get; set; }
    public virtual Account Account { get; set; }
}
