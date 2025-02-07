using AppService.Domain.Security.Request;
using FluentValidation;
using Repository;

namespace AppService.Domain.Security.Validator;

public class LoginValidator: AbstractValidator<LoginRequest>
{
    private readonly AppDbContext _appDbContext;
    public LoginValidator(AppDbContext appDbContext) 
    {
        _appDbContext = appDbContext;

        RuleFor(l => l.Email)
            .EmailAddress()
            .WithMessage("email inválido");
    }

    
}
