using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Application.Common.Interfaces.Services;
using Lubricentro.Application.EmployeeMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.EmployeeAggregate;
using Lubricentro.Domain.RoleAggregate;
using Lubricentro.Domain.RoleAggregate.ValueObjects;
using Lubricentro.Domain.UserAggregate;
using Lubricentro.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.EmployeeMediator.Command.Create;

public class CreateEmployeeCommandHandler(IRoleRepository roleRepositroy,IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork,IPasswordProvider passwordProvider) : IRequestHandler<CreateEmployeeCommand, ErrorOr<EmployeeResult>>
{
    private readonly IRoleRepository _roleRepository = roleRepositroy;
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
    private readonly IPasswordProvider _passwordProvider = passwordProvider;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<EmployeeResult>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Check if employee exists
        var employeeCheck = await _employeeRepository.GetByEmailAsync(request.Email);

        if(employeeCheck is not null)
        {
            return Errors.Employee.DuplicatedEmployee;
        }

        var newPassword = _passwordProvider.GenerateRandomPassword();

        Role? role = await _roleRepository.GetById(RoleId.Create(request.RoleId));
        // Generate unique Id and persist it
        
        if(role is null)
        {
            return Errors.Roles.NotFound;
        }
        var user = User.Create(request.Email, newPassword, role);
        var employee = Employee.Create(
            user,
            request.FirstName,
            request.LastName,
            request.Email);

        _employeeRepository.Add(employee);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // return the new Employee
        return new EmployeeResult(
                 employee.Id.Value.ToString(), employee.FirstName, employee.LastName, employee.Email,
                employee.User.Role.Id.Value.ToString(), employee.User.Role.Name);
    }
}
