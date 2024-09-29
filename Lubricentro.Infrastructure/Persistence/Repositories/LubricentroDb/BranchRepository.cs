using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.CompanyAggregate.Entities;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb;

internal class BranchRepository(LubricentroDbContext dbContext) : Repository<Branch, BranchId>(dbContext), IBranchRepository
{
    public async Task<bool> AlreadyExists(string PointOfSale, BranchId? branchId = null)
    {
        var branch = await DbContext.Branches.FirstOrDefaultAsync(b => b.PointOfSale == PointOfSale);
        if (branch is null) return false;

        // LOGIC FOR UPDATING 
        if(branchId is not null)
        {
            return branch.Id != branchId;
        }

        return true;
    }

    public async Task<IEnumerable<Branch>> GetAll()
    {
        return await DbContext.Branches.Include(b => b.Address).ToListAsync();
    }

    public async Task<IEnumerable<Branch>> GetByCompany(CompanyId companyId)
    {
        var company = await DbContext.Companies.Include(c => c.Branches).ThenInclude(b => b.Address).FirstOrDefaultAsync(c => c.Id == companyId);
        return company?.Branches ?? Enumerable.Empty<Branch>();
    }

    public async Task<Branch?> GetById(BranchId branchId)
    {
        return await DbContext.Branches.Include(b => b.Address).FirstOrDefaultAsync(b => b.Id == branchId);
    }
}
