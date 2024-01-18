using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Domain.EmployeeAggregate;
using Lubricentro.Domain.EmployeeAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories;

public class EmployeeRepository(LubricentroDbContext dbContext) : Repository<Employee, EmployeeId>(dbContext), IEmployeeRepository
{
    public async Task<Employee?> GetByEmailAsync(string email)
    {
        return await DbContext.Set<Employee>().FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<Employee?> GetByIdAsync(EmployeeId id)
    {
        var employee = await DbContext.Set<Employee>().FirstOrDefaultAsync(x => x.Id == id);
        return employee;
    }
}
