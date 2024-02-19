using ErrorOr;
using Lubricentro.Application.EmployeeMediator.Common;
using MediatR;

namespace Lubricentro.Application.EmployeeMediator.Command.Delete;

public record DeleteEmployeeCommand(Guid Id) : IRequest<ErrorOr<EmployeeResult>>
{
}
