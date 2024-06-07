using Lubricentro.Domain.MigrationAggregates;

namespace Lubricentro.Application.Common.Interfaces.Persistence.MigrationDb;

public interface IClientMigrationRepository : IMigrationRepository<ClientMigration>
{
    Task<ClientMigration?> GetByClientId(string id);
    Task<ClientMigration?> GetByClientId(int id);
}
