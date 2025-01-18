namespace AppService.Domain.Security.Request;

public record LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
