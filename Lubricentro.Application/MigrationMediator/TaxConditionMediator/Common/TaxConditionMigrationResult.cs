namespace Lubricentro.Application.MigrationMediator.TaxConditionMediator.Common;

public record TaxConditionMigrationResult(string Id, string Description, char Type, bool Vat)
{
}
