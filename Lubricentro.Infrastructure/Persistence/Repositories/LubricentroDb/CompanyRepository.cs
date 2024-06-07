using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.CompanyAggregate;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb;

internal class CompanyRepository(LubricentroDbContext dbContext) : Repository<Company, CompanyId>(dbContext), ICompanyRepository
{
    public Task<List<Company>> GetAllAsync()
    {
        return DbContext.Companies.ToListAsync();
    }

    public Task<Company?> GetByNameAsync(string name)
    {
        return DbContext.Companies.FirstOrDefaultAsync(x => x.Name == name);
    }
    public Task<Company?> GetByIdAsync(CompanyId Id)
    {
        return DbContext.Companies.FirstOrDefaultAsync(x => x.Id == Id);
    }
}
