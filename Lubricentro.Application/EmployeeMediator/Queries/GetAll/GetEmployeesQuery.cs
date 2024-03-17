using ErrorOr;
using Lubricentro.Application.EmployeeMediator.Common;
using MediatR;

namespace Lubricentro.Application.EmployeeMediator.Queries.GetAll;

public record GetEmployeesQuery() : IRequest<ErrorOr<List<EmployeeResult>>>
{
}
