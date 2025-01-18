using System.ComponentModel.DataAnnotations;

namespace Repository.Entity;

public record SubCateegory
{
    [Key]
    public Guid Id { get; init; }

    public string Name { get; set; }

    public Guid CategoryId { get; set; }

    public virtual Category Category { get; set; }
}
