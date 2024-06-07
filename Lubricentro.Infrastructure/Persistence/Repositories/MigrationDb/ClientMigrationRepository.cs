using Lubricentro.Application.Common.Interfaces.Persistence.MigrationDb;
using Lubricentro.Domain.MigrationAggregates;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.MigrationDb;

internal class ClientMigrationRepository(MigrationDbContext dbContext) : MigrationRepository<ClientMigration>(dbContext), IClientMigrationRepository
{
    public async Task<ClientMigration?> GetByClientId(int id)
    {
        return await DbContext.Clients.FirstOrDefaultAsync(c => c.Cli_Codigo == id);
    }

    public async Task<ClientMigration?> GetByClientId(string id)
    {
        return await DbContext.Clients.FirstOrDefaultAsync(c => c.ClientId == id);
    }
}
