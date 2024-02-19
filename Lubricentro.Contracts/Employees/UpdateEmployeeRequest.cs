namespace Lubricentro.Contracts.Employees;

public record UpdateEmployeeRequest(Guid Id, Guid RoleId, string FirstName, string LastName)
{
}
