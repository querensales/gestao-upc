namespace AppService.Domain.Account.Request;

public record AddUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Active { get; set; }
}
