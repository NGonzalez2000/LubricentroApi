using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Application.EmployeeMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.EmployeeAggregate.ValueObjects;
using Lubricentro.Domain.RoleAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.EmployeeMediator.Command.Update
{
    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IRoleRepository roleRepository) : IRequestHandler<UpdateEmployeeCommand, ErrorOr<EmployeeResult>>
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<ErrorOr<EmployeeResult>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(EmployeeId.Create(request.Id));
            if (employee is null)
            {
                return Errors.Employee.EmployeeNotFound;
            }

            employee.ChangeFirstName(request.FirstName);
            employee.ChangeLastName(request.LastName);

            var role = await _roleRepository.GetById(RoleId.Create(request.RoleId));

            if (role is null)
            {
                return Errors.Roles.NotFound;
            }

            employee.User.Role = role;

            _employeeRepository.Update(employee);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new EmployeeResult(
                employee.Id.Value.ToString(), employee.FirstName, employee.LastName, employee.Email,
                employee.User.Role.Id.Value.ToString(), employee.User.Role.Name);
        }

    }
}
