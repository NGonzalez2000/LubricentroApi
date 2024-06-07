namespace Lubricentro.Contracts.Clients;

public record CreateClientRequest(string Country,
                                  string State,
                                  string City,
                                  string Street,
                                  string PostalCode,
                                  string ClientName,
                                  Guid TaxConditionId,
                                  string Cuil,
                                  string Email,
                                  string PhoneNumber,
                                  string CellphoneNumber,
                                  string Observation,
                                  bool HasCheckingAccount,
                                  bool IsWholesaler)
{
}
