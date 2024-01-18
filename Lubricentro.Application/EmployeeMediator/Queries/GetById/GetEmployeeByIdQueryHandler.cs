using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Application.EmployeeMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.EmployeeAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.EmployeeMediator.Queries.GetById;

public class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository) 
    : IRequestHandler<GetEmployeeByIdQuery, ErrorOr<EmployeeResult>>
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public async Task<ErrorOr<EmployeeResult>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(EmployeeId.Create(request.Id));

        if(employee is null)
        {
            return Errors.Employee.EmployeeNotFound;
        }

        return new EmployeeResult(employee.Id.Value.ToString(), employee.FirstName, employee.LastName, employee.Email);
    }
}
