namespace Lubricentro.Contracts.Migrations.TaxCondition;

public record UpdateTaxConditionMigrationRequest(Guid Id, string Description, char Type, bool Vat)
{
}
