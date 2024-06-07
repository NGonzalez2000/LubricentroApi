using Lubricentro.Domain.EmployeeAggregate;
using Lubricentro.Domain.EmployeeAggregate.ValueObjects;
namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface IEmployeeRepository : IRepository<Employee, EmployeeId>
{
    Task<List<Employee>?> GetAll();
    Task<Employee?> GetByEmailAsync(string email);
    Task<Employee?> GetByIdAsync(EmployeeId id);

}
