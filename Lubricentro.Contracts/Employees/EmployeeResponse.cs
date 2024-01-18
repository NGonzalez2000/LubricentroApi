namespace Lubricentro.Contracts.Employees;

public record EmployeeResponse(
    string Id,
    string FirstName,
    string LastName,
    string Email
    );