using FluentValidation;

namespace Lubricentro.Application.RoleMediator.Command.Create;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Policies.Count == x.Policies.Distinct().Count());
    }
}
