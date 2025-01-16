using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AppService.Domain;
using AppService.Domain.Account.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository;

namespace AppService.Application;

public class SecurityService : ISecurityService
{
    private readonly AppDbContext _appDbContext;
    private readonly IConfiguration _configuration;
    public SecurityService(
        AppDbContext appDbContext, 
        IConfiguration configuration)
    {
        _appDbContext = appDbContext;
        _configuration = configuration;
    }

    public async Task AddUser(AddUserRequest request)
    {
        await _appDbContext.User.AddAsync(new Repository.Entity.User
        {
            Email = request.Email,
            Id = Guid.NewGuid(),
            Password = request.Password
        });

        await _appDbContext.SaveChangesAsync();
    }

    public async Task ForgotPassword(string email)
    {
        var user = await _appDbContext.User.SingleAsync(u => u.Email == email);
    
        if (user != null) 
        {
            user.Password = "123456";
            _appDbContext.Update(user);
            await _appDbContext.SaveChangesAsync();
        }
    }

    public async ValueTask<string> SignIn(LoginRequest loginRequest)
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

        return GenerateJwtToken(user.Email);
    }


    private string GenerateJwtToken(string username)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            // Adicione outras claims conforme necessário (ex: roles)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            //issuer: _configuration["Jwt:Issuer"],
            //audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1), // Tempo de expiração do token
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
