using ErrorOr;
using Lubricentro.Application.EmployeeMediator.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Lubricentro.Application.EmployeeMediator.Command.Create;

public record CreateEmployeeCommand(
    byte[]? ImageData,
    Guid RoleId,
    string FirstName,
    string LastName,
    string Email) : IRequest<ErrorOr<EmployeeResult>>;
