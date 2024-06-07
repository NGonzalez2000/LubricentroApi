using Lubricentro.Domain.CompanyAggregate.Entities;

namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface ICompanyServiceRepository
{
    void UpdateAllAsync(List<CompanyService> companyServices);
    Task<List<CompanyService>> GetAllAsync();
}
