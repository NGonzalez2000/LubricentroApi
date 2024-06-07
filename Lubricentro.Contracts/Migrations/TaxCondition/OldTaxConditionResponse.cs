namespace Lubricentro.Contracts.Migrations.TaxCondition;

public record OldTaxConditionResponse(string Id,
                       string Description,
                       string Type,
                       bool VAT)
{
}
