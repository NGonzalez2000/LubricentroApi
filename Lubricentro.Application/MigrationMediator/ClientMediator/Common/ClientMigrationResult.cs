using Lubricentro.Application.EmailMediator;
using Lubricentro.Application.MigrationMediator.TaxConditionMediator.Common;
using Lubricentro.Application.PhoneMediator;
using Lubricentro.Domain.AddressAggregate;

namespace Lubricentro.Application.MigrationMediator.ClientMediator.Common;

public record ClientMigrationResult(string Id,
                                    Address Address,
                                    TaxConditionMigrationResult TaxCondition,
                                    string ClientName,
                                    string Cuil,
                                    bool HasEmailNotification,
                                    List<EmailResult> Emails,
                                    bool HasPhoneNotification,
                                    List<PhoneResult> Phones,
                                    string Observation,
                                    bool HasCheckingAccount,
                                    bool IsWholesaler)
{
}
