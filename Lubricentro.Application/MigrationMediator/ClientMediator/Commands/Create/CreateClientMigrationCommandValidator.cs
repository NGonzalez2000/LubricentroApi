using FluentValidation;
using Lubricentro.Application.Common.Interfaces.Services;

namespace Lubricentro.Application.MigrationMediator.ClientMediator.Commands.Create;

public class CreateClientMigrationCommandValidator : AbstractValidator<CreateClientMigrationCommand>
{
    public CreateClientMigrationCommandValidator(ICuilService cuilService)
    {
        RuleFor(x => x.ClientName).NotEmpty().WithMessage("Necesita un nombre");
        RuleFor(x => x.TaxConditionId).NotEmpty().WithMessage("Necesita Cond. Cliente");
        //RuleFor(x => x.Cuil).Must(cuilService.ValidateCuil).WithMessage("CUIL/CUIT Invalido");
        RuleFor(x => x.ClientName).Must(name => !name.Contains("NO USAR")).WithMessage("NO USAR!");
        RuleFor(x => x.CellphoneNumber).MaximumLength(20);
        RuleFor(x => x.PhoneNumber).MaximumLength(20);
    }
}
