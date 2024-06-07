namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
