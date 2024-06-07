using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.CompanyAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb;

internal class CompanyServiceRepository(LubricentroDbContext dbContext) : ICompanyServiceRepository
{
    public Task<List<CompanyService>> GetAllAsync()
    {
        return dbContext.CompanyServices.Include(cs => cs.Company).ToListAsync();
    }

    public void UpdateAllAsync(List<CompanyService> companyServices)
    {
        foreach (var companyService in companyServices)
        {
            dbContext.CompanyServices.Update(companyService);
        }
    }
}
