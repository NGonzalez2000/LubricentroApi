using Lubricentro.Domain.EmployeeAggregate;
using Lubricentro.Domain.EmployeeAggregate.ValueObjects;
namespace Lubricentro.Application.Common.Interfaces.Persistence;

public interface IEmployeeRepository : IRepository<Employee, EmployeeId>
{
    Task<Employee?> GetByEmailAsync(string email);
    Task<Employee?> GetByIdAsync(EmployeeId id);
}
