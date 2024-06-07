using Lubricentro.Domain.CompanyAggregate;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface ICompanyRepository : IRepository<Company, CompanyId>
{
    Task<List<Company>> GetAllAsync();
    Task<Company?> GetByNameAsync(string name);
    Task<Company?> GetByIdAsync(CompanyId Id);
}
