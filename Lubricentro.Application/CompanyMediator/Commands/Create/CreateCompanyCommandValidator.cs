using FluentValidation;
using Lubricentro.Application.Common.Interfaces.Services;

namespace Lubricentro.Application.CompanyMediator.Commands.Create;

internal class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator(ICuilService cuilService)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Debe asignarle un nombre a la empresa");
        RuleFor(x => x.Name)
            .MaximumLength(50)
            .WithMessage("El nombre de la empresa no puede exceder los 50 caracteres.");
        RuleFor(x => x.Cuil)
            .Must(cuilService.ValidateCuil);
    }
}
