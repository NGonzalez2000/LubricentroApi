using Lubricentro.Contracts.Emails;
using Lubricentro.Contracts.Phones;

namespace Lubricentro.Contracts.Clients;

public record CreateClientRequest(string Country,
                                  string State,
                                  string City,
                                  string Street,
                                  string PostalCode,
                                  string ClientName,
                                  Guid TaxConditionId,
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
