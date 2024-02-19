using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.EmailAggregate.ValueObjects;

namespace Lubricentro.Domain.EmailAggregate;

public class Email : AggregateRoot<EmailId, Guid>
{
    public string Mail { get; set; }
    private Email(EmailId id, string mail)
		: base(id)
	{
		Mail = mail;
	}

	public static Email Create(string mail)
	{
		return new(EmailId.CreateUnique(), mail);
	}
}
