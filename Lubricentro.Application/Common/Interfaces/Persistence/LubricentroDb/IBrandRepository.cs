using Lubricentro.Domain.BrandAggregate;
using Lubricentro.Domain.BrandAggregate.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface IBrandRepository : IRepository<Brand, BrandId>
{
    Task<List<Brand>> GetAllAsync();
    Task<Brand?> GetByNameAsync(string name);
    Task<Brand?> GetByIdAsync(BrandId Id);
}
