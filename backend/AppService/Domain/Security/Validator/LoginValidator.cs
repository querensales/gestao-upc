using AppService.Domain.Security.Request;
using FluentValidation;
using Repository;

namespace AppService.Domain.Security.Validator;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    private readonly AppDbContext _appDbContext;
    public LoginValidator(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;

        RuleFor(l => l.Email)
            .EmailAddress()
            .WithMessage("email inválido");

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
            .WithMessage("Email não foi preenchido")
            .NotNull()
            .WithMessage("Email não preenchido");

        RuleFor(u => u.Password)
            .NotEmpty()
            .WithMessage("Senha não preenchida")
            .NotNull()
            .WithMessage("Senha não preenchida");
    }
}
