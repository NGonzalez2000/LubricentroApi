using Lubricentro.Contracts.Emails;
using Lubricentro.Contracts.Phones;

namespace Lubricentro.Contracts.Clients;

public record UpdateClientRequest(Guid Id,
                                  string Country,
                                  string State,
                                  string City,
                                  string Street,
                                  string PostalCode,
                                  Guid TaxConditionId,
                                  string ClientName,
                                  string Cuil,
                                  bool HasEmailNotification,
                                  List<EmailRequest> Emails,
                                  bool HasPhoneNotification,
                                  List<PhoneRequest> Phones,
                                  string Observation,
                                  bool HasCheckingAccount,
                                  bool IsWholesaler)
{
}
