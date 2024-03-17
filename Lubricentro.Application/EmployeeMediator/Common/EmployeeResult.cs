using Microsoft.AspNetCore.Http;

namespace Lubricentro.Application.EmployeeMediator.Common;

public record EmployeeResult(byte[]? Image, string Id, string FirstName, string LastName, string Email,string RoleId, string RoleName);
