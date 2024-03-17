using ErrorOr;
using Lubricentro.Application.EmployeeMediator.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Lubricentro.Application.EmployeeMediator.Command.Update;

public record UpdateEmployeeCommand(
    byte[]? ImageData,
    Guid Id,
    Guid RoleId,
    string FirstName,
    string LastName) : IRequest<ErrorOr<EmployeeResult>> { }
