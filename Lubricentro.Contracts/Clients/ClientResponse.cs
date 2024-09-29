using Lubricentro.Contracts.Emails;
using Lubricentro.Contracts.Phones;
using Lubricentro.Contracts.TaxContitions;

namespace Lubricentro.Contracts.Clients;

public record ClientResponse(string Id,
                             string AddressId,
                             string Country,
                             string State,
                             string City,
                             string Street,
                             string PostalCode,
                             TaxConditionResponse TaxCondition,
                             string ClientName,
                             string Cuil,
                             bool HasEmailNotification,
                             List<EmailResponse> Emails,
                             bool HasPhoneNotification,
                             List<PhoneResponse> Phones,
                             string Observation,
                             bool HasCheckingAccount,
                             bool IsWholesaler)
{
}
