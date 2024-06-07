using FluentValidation;

namespace Lubricentro.Application.ClientMediator.Commands.Create;

internal class CreateClientCommandValidation : AbstractValidator<CreateClientCommand>
{
    public CreateClientCommandValidation()
    {
        RuleFor(x => x.ClientName).NotEmpty().WithMessage("Debe asignarle un nombre");
    }
}
