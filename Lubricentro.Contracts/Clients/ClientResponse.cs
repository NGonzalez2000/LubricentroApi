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
                             string Email,
                             string PhoneNumber,
                             string CellphoneNumber,
                             string Observation,
                             bool HasCheckingAccount,
                             bool IsWholesaler)
{
}
