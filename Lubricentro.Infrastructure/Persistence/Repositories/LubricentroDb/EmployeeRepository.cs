using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.EmployeeAggregate;
using Lubricentro.Domain.EmployeeAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb;

public class EmployeeRepository(LubricentroDbContext dbContext) : Repository<Employee, EmployeeId>(dbContext), IEmployeeRepository
{
    public async Task<List<Employee>?> GetAll()
    {
        return await DbContext.Employees.Include(e => e.User).ThenInclude(u => u.Role).ToListAsync();
    }

    public async Task<Employee?> GetByEmailAsync(string email)
    {
        return await DbContext.Employees.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<Employee?> GetByIdAsync(EmployeeId id)
    {
        return await DbContext.Employees.Include(e => e.User).ThenInclude(u => u.Role).FirstOrDefaultAsync(x => x.Id == id);
    }
}
