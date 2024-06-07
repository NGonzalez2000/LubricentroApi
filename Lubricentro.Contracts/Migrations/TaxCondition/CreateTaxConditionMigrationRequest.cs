namespace Lubricentro.Contracts.Migrations.TaxCondition;

public record CreateTaxConditionMigrationRequest(string OldId, string Description, char Type, bool Vat)
{
}
