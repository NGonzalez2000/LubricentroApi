using Microsoft.AspNetCore.Http;

namespace Lubricentro.Contracts.Employees;

public record CreateEmployeeRequest(
        byte[]? ImageData,
        string FirstName,
        string LastName,
        string Email,
        Guid RoleId
    );
