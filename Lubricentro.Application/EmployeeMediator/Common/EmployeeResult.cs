namespace Lubricentro.Application.EmployeeMediator.Common;

public record EmployeeResult(byte[]? Image, string Id, string FirstName, string LastName,string Cuil, string Email,string RoleId, string RoleName);
