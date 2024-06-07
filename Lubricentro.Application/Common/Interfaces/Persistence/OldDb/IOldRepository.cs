namespace Lubricentro.Application.Common.Interfaces.Persistence.OldDb
{
    public interface IOldRepository<T>
        where T : class
    {
        Task<List<T>> GetAllAsync();
    }
}
