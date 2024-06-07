namespace Lubricentro.Contracts.Migrations.TaxCondition;

public record TaxConditionMigrationResponse(string Id, string Description, char Type, bool Vat)
{
}
