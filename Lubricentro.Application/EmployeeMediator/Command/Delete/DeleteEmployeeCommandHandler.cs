using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Application.EmployeeMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.EmployeeAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.EmployeeMediator.Command.Delete;

public class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUserRepository userRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteEmployeeCommand, ErrorOr<EmployeeResult>>
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<EmployeeResult>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(EmployeeId.Create(request.Id));

        if (employee is null)
        {
            return Errors.Employee.EmployeeNotFound;
        }

        _userRepository.Delete(employee.User);

        _employeeRepository.Delete(employee);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new EmployeeResult(
                employee.Id.Value.ToString(), employee.FirstName, employee.LastName, employee.Email,
                "","");
    }
}
