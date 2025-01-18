namespace AppService.Domain.Security.Request;

public record AddUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string RepeatPassword { get; set; }
    public bool Active { get; set; }
}
