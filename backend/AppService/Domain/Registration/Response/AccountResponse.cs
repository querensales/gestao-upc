using Repository.Entity;

namespace AppService.Domain.Registration.Response;

public record AccountResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public static AccountResponse FromEntity(Account entity)
    {

    }
}
