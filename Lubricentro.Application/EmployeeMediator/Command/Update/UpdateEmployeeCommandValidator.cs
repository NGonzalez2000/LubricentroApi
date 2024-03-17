using FluentValidation;

namespace Lubricentro.Application.EmployeeMediator.Command.Update;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(x => x.LastName).NotEmpty().WithMessage("El 'Apellido' no puede estar vacio");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("El 'Nombre' no puede estar vacio");
    }
}
