using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.AddressAggregate;

namespace Lubricentro.Application.ClientMediator.Common;

public record ClientResult(string Id,
                           Address Address,
                           TaxConditionResult TaxCondition,
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
