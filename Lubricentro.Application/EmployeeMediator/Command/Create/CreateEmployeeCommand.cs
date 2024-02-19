using ErrorOr;
using Lubricentro.Application.EmployeeMediator.Common;
using MediatR;

namespace Lubricentro.Application.EmployeeMediator.Command.Create;

public record CreateEmployeeCommand(
    Guid RoleId,
    string FirstName,
    string LastName,
    string Email) : IRequest<ErrorOr<EmployeeResult>>;
