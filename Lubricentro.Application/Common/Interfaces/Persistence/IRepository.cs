using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Application.Common.Interfaces.Persistence;

public interface IRepository<TEntity,TId>
    where TEntity : Entity<TId>
    where TId : AggregateRootId<Guid>
{
    void Add(TEntity repository);
    void Update(TEntity repository);
    void Delete(TEntity repository);
    List<TEntity> GetAll();
}
