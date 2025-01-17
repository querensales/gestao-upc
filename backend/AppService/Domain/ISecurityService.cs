using AppService.Domain.Account.Request;

namespace AppService.Domain;

public interface ISecurityService
{
    Task AddUser(AddUserRequest request);
    ValueTask<string> SignIn(LoginRequest loginRequest);
    Task ForgotPassword(string email);
}
