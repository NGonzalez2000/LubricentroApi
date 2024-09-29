using Lubricentro.Domain.EmailAggregates;

namespace Lubricentro.Application.EmailMediator;

public record EmailResult(string Id, string Value, bool IsActive)
{
    public EmailResult(Email email) : this(email.Id.Value.ToString(), email.Value, email.IsActive)
    {
    }
}
