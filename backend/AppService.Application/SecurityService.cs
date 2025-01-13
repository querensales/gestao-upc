using AppService.Domain;
using AppService.Domain.Account.Request;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace AppService.Application;

public class SecurityService : ISecurityService
{
    private readonly AppDbContext _appDbContext;

    public SecurityService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task SignIn(LoginRequest loginRequest)
    {
        var user = await _appDbContext
                            .User
                            .SingleOrDefaultAsync(u =>
                                u.Email == loginRequest.Email &&
                                u.Password == loginRequest.Password);
        if (user == null)
        {
            throw new NullReferenceException("Usuário não encontrado");
        }
    }
}
