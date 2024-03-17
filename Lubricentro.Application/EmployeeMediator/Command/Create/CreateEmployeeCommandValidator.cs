using FluentValidation;

namespace Lubricentro.Application.EmployeeMediator.Command.Create;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("El Email no es valido");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("El 'Apellido' no puede estar vacio");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("El 'Nombre' no puede estar vacio");
    }
}
