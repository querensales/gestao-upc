﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AppService.Domain;
using AppService.Domain.Security.Request;
using AppService.Domain.Security.Validator;
using AppService.Extension;
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
        var validator = new AddUserValidator(_appDbContext);
        var validate = validator.Validate(request);
        if (!validate.IsValid)
        {
            throw new CustomValidationException( validate.Errors);
        }
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
            user.Password = JwtExtensions.HashPassword("123456");
            _appDbContext.Update(user);
            await _appDbContext.SaveChangesAsync();
        }
    }

    public async ValueTask<string> SignIn(LoginRequest loginRequest)
    {
        var validate = new LoginValidator(_appDbContext).Validate(loginRequest);
        if (!validate.IsValid)
        {
            throw new CustomValidationException(validate.Errors);
        }

        var user = await _appDbContext
                            .User
                            .SingleOrDefaultAsync(u =>
                                u.Email == loginRequest.Email);

        return GenerateJwtToken(user.Email);
    }


    private string GenerateJwtToken(string username)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1), 
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
