using Lubricentro.Domain.CompanyAggregate.Entities;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface IBranchRepository : IRepository<Branch, BranchId>
{
    Task<bool> AlreadyExists(string PointOfSale, BranchId? branchId = null);
    Task<Branch?> GetById(BranchId branchId);
    Task<IEnumerable<Branch>> GetAll();
    Task<IEnumerable<Branch>> GetByCompany(CompanyId companyId);
}
