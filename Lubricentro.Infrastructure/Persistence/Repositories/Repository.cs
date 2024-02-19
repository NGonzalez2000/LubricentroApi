using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Infrastructure.Persistence.Repositories;

public abstract class Repository<TEntity,TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : AggregateRootId<Guid>
{
    protected readonly LubricentroDbContext DbContext;
    protected Repository(LubricentroDbContext dbContext)
    {
          DbContext = dbContext;
    }
    public void Add(TEntity entity)
    {
        DbContext.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        DbContext.Set<TEntity>().Update(entity);
    }
    public void Delete(TEntity entity)
    {
        DbContext.Set<TEntity>().Remove(entity);
    }
}
