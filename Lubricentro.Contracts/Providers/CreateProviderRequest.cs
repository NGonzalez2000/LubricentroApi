using Lubricentro.Contracts.Emails;
using Lubricentro.Contracts.Phones;

namespace Lubricentro.Contracts.Providers;

public record CreateProviderRequest(string Name,
                                    string Cuil,
                                    List<PhoneRequest> Phones,
                                    List<EmailRequest> Emails,
                                    string Fax,
                                    string Observation,
                                    string Website,
                                    string Country,
                                    string State,
                                    string City,
                                    string Street,
                                    string PostalCode,
                                    Guid TaxConditionId)
{
}
