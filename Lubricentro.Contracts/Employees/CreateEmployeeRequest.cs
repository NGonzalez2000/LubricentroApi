namespace Lubricentro.Contracts.Employees;

public record CreateEmployeeRequest(
        string FirstName,
        string LastName,
        string Email,
        Guid RoleId
    );
