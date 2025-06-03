using AppService.Domain.Security.Request;
using AppService.Extension;
using FluentValidation;
using Repository;

namespace AppService.Domain.Security.Validator;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    private readonly AppDbContext _appDbContext;
    public LoginValidator(AppDbContext appDbContext) 
    {
        _appDbContext = appDbContext;

        RuleFor(u => u.Email)
        .Custom((Email, context) =>
        {
            if (!_appDbContext.User.Any(u => u.Email == Email))
            {
                context.AddFailure("Email inexistente-.");
            }
        });

        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("Email está vazio")
            .NotNull()
            .WithMessage("Email nulo");

        RuleFor(u => u.Password)
            .NotEmpty()
            .WithMessage("Senha vazia")
            .NotNull()
            .WithMessage("Senha nula");

        RuleFor(u => u)
            .Custom((u, context) =>
            {
                if (!UserIsValid(u.Email, u.Password))
                {
                    context.AddFailure("Usuário ou senha inválido");
                }
            });
    }

    private bool UserIsValid(string email, string password)
    {
        var employee =
             _appDbContext
                    .User
                    .SingleOrDefault(e => e.Email == email);
        if (employee == null)
        {
            return false;
        }

        return JwtExtensions.VerifyPassword(password, employee.Password);
    }
}