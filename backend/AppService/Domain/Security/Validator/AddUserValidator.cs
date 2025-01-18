using AppService.Domain.Security.Request;
using FluentValidation;
using Repository;

namespace AppService.Domain.Account.Validator;

public class AddUserValidator: AbstractValidator<AddUserRequest>
{
    private readonly AppDbContext _appDbContext;
    public AddUserValidator(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Campo Email é obrigatório")
            .Custom((email, context) =>
            {
                if (_appDbContext.User.Any(u => u.Email == email))
                { 
                    context.AddFailure("Já existe um produto com este nome.");
                }
            });

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Campo email é obrigatório")
            .Equal(x => x.RepeatPassword, StringComparer.OrdinalIgnoreCase).WithMessage("A senha e a confirmação de senha não correspondem.");
    }
}
