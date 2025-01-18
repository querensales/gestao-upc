namespace AppService.Domain.Registration.Response;

public record CreditCardResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}
