using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.Common.Interfaces.Services;
using Lubricentro.Application.EmployeeMediator.Common;
using Lubricentro.Domain.Common.Errors;
using MediatR;

namespace Lubricentro.Application.EmployeeMediator.Queries.GetAll;

public class GetEmployeesQueryHandler(IEmployeeRepository employeeRepository, IImageService imageService) : IRequestHandler<GetEmployeesQuery, ErrorOr<List<EmployeeResult>>>
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
    private readonly IImageService _imageService = imageService;
    public async Task<ErrorOr<List<EmployeeResult>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _employeeRepository.GetAll();
        
        if(employees == null)
        {
            return Errors.Employee.EmployeeNotFound;
        }

        List<EmployeeResult> result = [];

        foreach(var employee in employees)
        {
            var image = _imageService.GetImage(employee.ImageName);
            result.Add(new(image,
                employee.Id.Value.ToString(),
                           employee.FirstName,
                           employee.LastName,
                           employee.Email,
                           employee.User.Role.Id.Value.ToString(),
                           employee.User.Role.Name));
        }

        return result;
    }
}
