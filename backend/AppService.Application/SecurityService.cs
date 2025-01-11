using AppService.Domain;
using AppService.Domain.Account.Request;

namespace AppService.Application;

public class SecurityService : ISecurityService
{
    public Task SignIn(LoginRequest loginRequest)
    {
        throw new NotImplementedException();
    }
}
