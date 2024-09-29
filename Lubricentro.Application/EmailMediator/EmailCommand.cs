namespace Lubricentro.Application.EmailMediator;

public record EmailCommand(Guid Id, string Value, bool IsActive)
{
}
