using Lubricentro.Contracts.Emails;
using Lubricentro.Contracts.Phones;

namespace Lubricentro.Contracts.Migrations.Client;

public record OldClientResponse(string Id,
                               string AddressId,
                               string Country,
                               string State,
                               string City,
                               string Street,
                               string PostalCode,
                               string TaxConditionId,
                               string TaxConditionDescription,
                               char TaxConditionType,
                               bool TaxConditionVAT,
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
