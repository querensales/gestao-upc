using AppService.Domain.Account.Request;

namespace AppService.Domain;

public interface ISecurityService
{
    ValueTask<string> SignIn(LoginRequest loginRequest);
}
