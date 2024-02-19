using Lubricentro.Application.RoleMediator.Common;

namespace Lubricentro.Application.EmployeeMediator.Common;

public record EmployeeResult(string Id, string FirstName, string LastName, string Email,string RoleId, string RoleName);
