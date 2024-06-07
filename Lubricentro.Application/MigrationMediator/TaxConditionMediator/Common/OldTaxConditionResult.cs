namespace Lubricentro.Application.MigrationMediator.TaxConditionMediator.Common;

public record OldTaxConditionResult(string Id,
                       string Description,
                       string Type,
                       bool VAT)
{
}
