using Lubricentro.Domain.TaxConditionAggregate;

namespace Lubricentro.Application.TaxConditionMediator.Common;

public record TaxConditionResult(string Id, string Description, char Type, bool Vat)
{
    public TaxConditionResult(TaxCondition taxCondition) 
        : this(taxCondition.Id.Value.ToString(), taxCondition.Description, taxCondition.Type, taxCondition.VAT)
    { 
    }
}
