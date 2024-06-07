namespace Lubricentro.Contracts.TaxContitions;

public record CreateTaxConditionRequest(string Description, char Type, bool Vat)
{
}
