using Lubricentro.Application.Common.Interfaces.Persistence.MigrationDb;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.MigrationDb;

internal class MigrationRepository<T> : IMigrationRepository<T> where T : class
{
    protected readonly MigrationDbContext DbContext;
    protected MigrationRepository(MigrationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public void Add(T entity)
    {
        DbContext.Add(entity);
        DbContext.SaveChanges();
    }

    public void Delete(T entity)
    {
        DbContext.Remove(entity);
        DbContext.SaveChanges();

    }

    public async Task<List<T>> GetAllAsync()
    {
        return await DbContext.Set<T>().ToListAsync();
    }
}
