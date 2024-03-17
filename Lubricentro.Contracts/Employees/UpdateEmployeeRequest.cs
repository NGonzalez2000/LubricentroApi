using Microsoft.AspNetCore.Http;

namespace Lubricentro.Contracts.Employees;

public record UpdateEmployeeRequest(byte[]? ImageData, Guid Id, Guid RoleId, string FirstName, string LastName)
{
}
