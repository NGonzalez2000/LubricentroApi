using FluentValidation;

namespace Lubricentro.Application.ClientMediator.Commands.Update;

internal class UpdateClientCommandValidation : AbstractValidator<UpdateClientCommand>
{
    public UpdateClientCommandValidation()
    {
        RuleFor(x => x.ClientName).NotEmpty().WithMessage("Debe asignar un nombre al cliente");
    }
}
