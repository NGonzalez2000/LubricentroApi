using FluentValidation;

namespace Lubricentro.Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Se requiere un usuario");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Se requiere contraseña");
    }
}
