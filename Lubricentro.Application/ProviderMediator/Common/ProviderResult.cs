using Lubricentro.Application.AddressMediator.Common;
using Lubricentro.Application.EmailMediator;
using Lubricentro.Application.PhoneMediator;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.EmailAggregates;
using Lubricentro.Domain.PhoneAggregate;
using Lubricentro.Domain.ProviderAggregate;

namespace Lubricentro.Application.ProviderMediator.Common;

public record ProviderResult(string Id,
                             string Name,
                             string Cuil,
                             List<PhoneResult> Phones,
                             List<EmailResult> Emails,
                             string Fax,
                             string Observation,
                             string Website,
                             AddressResult Address,
                             TaxConditionResult TaxCondition)
{
    public ProviderResult(Provider provider) 
        : this(provider.Id.Value.ToString(),
               provider.Name,
               provider.Cuil,
               [],
               [],
               provider.Fax,
               provider.Observation,
               provider.Website,
               new AddressResult(provider.Address),
               new TaxConditionResult(provider.TaxCondition))
    {
        foreach(Phone phone in provider.Phones)
        {
            Phones.Add(new PhoneResult(phone));
        }

        foreach(Email email in provider.Emails)
        {
            Emails.Add(new EmailResult(email));
        }
    }
}
