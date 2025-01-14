using AppService.Domain.Account.Request;

namespace AppService.Domain;

public interface ISecurityService
{
    Task SignIn(LoginRequest loginRequest);
}
