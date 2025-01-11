using AppService.Domain.Account.Request;

namespace AppService.Domain;

public interface ISecurityService
{
    public Task SignIn(LoginRequest loginRequest);
}
