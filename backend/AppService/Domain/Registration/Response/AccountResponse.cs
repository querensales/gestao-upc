using Repository.Entity;

namespace AppService.Domain.Registration.Response;

public record AccountResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public static AccountResponse FromEntity(Account entity)
    {
        return new AccountResponse
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
}
