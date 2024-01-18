using ErrorOr;
using Lubricentro.Application.EmployeeMediator.Common;
using MediatR;

namespace Lubricentro.Application.EmployeeMediator.Queries.GetById;

public record GetEmployeeByIdQuery(Guid Id) : IRequest<ErrorOr<EmployeeResult>>;
