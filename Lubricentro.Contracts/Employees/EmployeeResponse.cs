using Microsoft.AspNetCore.Http;

namespace Lubricentro.Contracts.Employees;

public record EmployeeResponse(
    byte[]? Image,
    string Id,
    string FirstName,
    string LastName,
    string Email,
    string RoleId,
    string RoleName
    );
