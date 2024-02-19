using FluentValidation;

namespace Lubricentro.Application.RoleMediator.Command.Update;

public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();   
    }
}

