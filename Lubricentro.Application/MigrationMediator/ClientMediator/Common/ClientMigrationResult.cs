using Lubricentro.Application.MigrationMediator.TaxConditionMediator.Common;
using Lubricentro.Domain.AddressAggregate;

namespace Lubricentro.Application.MigrationMediator.ClientMediator.Common;

public record ClientMigrationResult(string Id,
                                    Address Address,
                                    TaxConditionMigrationResult TaxCondition,
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
