namespace Lubricentro.Contracts.Emails;

public record EmailRequest(Guid Id, string Value, bool IsActive)
{
}
