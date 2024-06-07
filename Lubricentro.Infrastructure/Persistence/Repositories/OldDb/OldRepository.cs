using Lubricentro.Application.Common.Interfaces.Persistence.OldDb;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.OldDb;

internal class OldRepository<T> : IOldRepository<T>
    where T : class
{
    protected readonly OldDbContext DbContext;
    protected OldRepository(OldDbContext dbContext)
    {
        DbContext = dbContext;
    }
    public async Task<List<T>> GetAllAsync()
    {
        return await DbContext.Set<T>().ToListAsync();
    }
}
