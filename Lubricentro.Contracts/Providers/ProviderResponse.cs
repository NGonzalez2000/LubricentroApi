using Lubricentro.Contracts.Address;
using Lubricentro.Contracts.Emails;
using Lubricentro.Contracts.Phones;
using Lubricentro.Contracts.TaxContitions;

namespace Lubricentro.Contracts.Providers;

public record ProviderResponse(string Id,
                               string Name,
                               string Cuil,
                               List<PhoneResponse> Phones,
                               List<EmailResponse> Emails,
                               string Fax,
                               string Observation,
                               string Website,
                               AddressResponse Address,
                               TaxConditionResponse TaxCondition)
{
}
