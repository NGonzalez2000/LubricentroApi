using Lubricentro.Application.EmailMediator;
using Lubricentro.Application.PhoneMediator;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.AddressAggregate;

namespace Lubricentro.Application.ClientMediator.Common;

public record ClientResult(string Id,
                           Address Address,
                           TaxConditionResult TaxCondition,
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
