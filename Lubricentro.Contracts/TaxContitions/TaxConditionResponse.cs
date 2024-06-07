namespace Lubricentro.Contracts.TaxContitions;

public record TaxConditionResponse(string Id, string Description, char Type, bool Vat)
{
}
