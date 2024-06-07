namespace Lubricentro.Application.MigrationMediator.ClientMediator.Common;

public record OldClientResult(string Id,
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
                       string Email,
                       string PhoneNumber,
                       string CellphoneNumber,
                       string Observation,
                       bool HasCheckingAccount,
                       bool IsWholesaler)
{
}
