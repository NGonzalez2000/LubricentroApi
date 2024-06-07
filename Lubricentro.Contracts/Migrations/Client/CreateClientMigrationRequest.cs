namespace Lubricentro.Contracts.Migrations.Client;

public record CreateClientMigrationRequest(string Id,
                                           string Country,
                                           string State,
                                           string City,
                                           string Street,
                                           string PostalCode,
                                           Guid TaxConditionId,
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
