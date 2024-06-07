namespace Lubricentro.Application.Common.Interfaces.Persistence.MigrationDb;

public interface IMigrationRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    void Add(T entity);
    void Delete(T entity);
}
