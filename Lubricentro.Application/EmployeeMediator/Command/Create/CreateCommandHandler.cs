using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Application.Common.Interfaces.Services;
using Lubricentro.Application.EmployeeMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.EmployeeAggregate;
using Lubricentro.Domain.EmployeeAggregate.ValueObjects;
using Lubricentro.Domain.UserAggregate;
using MediatR;

namespace Lubricentro.Application.EmployeeMediator.Command.Create;

public class CreateCommandHandler(IEmployeeRepository employeeRepository, IUserRepository userRepository, IUnitOfWork unitOfWork,IPasswordProvider passwordProvider) : IRequestHandler<CreateCommand, ErrorOr<EmployeeResult>>
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordProvider _passwordProvider = passwordProvider;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<EmployeeResult>> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Check if employee exists
        var employeeCheck = await _employeeRepository.GetByEmailAsync(request.Email);

        if(employeeCheck is not null)
        {
            return Errors.Employee.DuplicatedEmployee;
        }

        // Generate unique Id and persist it
        var employee = Employee.Create(
            request.FirstName,
            request.LastName,
            request.Email);

        _employeeRepository.Add(employee);

        var newPassword = _passwordProvider.GenerateRandomPassword();
        var user = User.Create(EmployeeId.Create(employee.Id.Value), request.Email, newPassword);

        _userRepository.Add(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // return the new Employee
        return new EmployeeResult(employee.Id.Value.ToString(), employee.FirstName, employee.LastName, employee.Email);    
    }
}
