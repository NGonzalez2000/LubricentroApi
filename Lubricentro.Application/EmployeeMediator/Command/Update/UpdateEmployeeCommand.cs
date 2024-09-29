using ErrorOr;
using Lubricentro.Application.EmployeeMediator.Common;
using MediatR;

namespace Lubricentro.Application.EmployeeMediator.Command.Update;

public record UpdateEmployeeCommand(
    byte[]? ImageData,
    Guid Id,
    Guid RoleId,
    string FirstName,
    string LastName,
    string Cuil) : IRequest<ErrorOr<EmployeeResult>> { }
