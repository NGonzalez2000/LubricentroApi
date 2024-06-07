using Lubricentro.Application.Common.Interfaces.Persistence.MigrationDb;
using Lubricentro.Domain.MigrationAggregates;

namespace Lubricentro.Infrastructure.Persistence.Repositories.MigrationDb;

internal class TaxConditionMigrationRepository(MigrationDbContext dbContext) : MigrationRepository<TaxConditionMigration>(dbContext), ITaxConditionMigrationRepository
{
}
