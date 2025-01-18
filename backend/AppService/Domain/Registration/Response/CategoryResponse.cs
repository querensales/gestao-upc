namespace AppService.Domain.Registration.Response;

public record CategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
