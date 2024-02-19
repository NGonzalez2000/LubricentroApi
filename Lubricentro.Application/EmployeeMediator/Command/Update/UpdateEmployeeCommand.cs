using ErrorOr;
using Lubricentro.Application.EmployeeMediator.Common;
using MediatR;

namespace Lubricentro.Application.EmployeeMediator.Command.Update;

public record UpdateEmployeeCommand(
    Guid Id,
    Guid RoleId,
    string FirstName,
    string LastName) : IRequest<ErrorOr<EmployeeResult>> { }
