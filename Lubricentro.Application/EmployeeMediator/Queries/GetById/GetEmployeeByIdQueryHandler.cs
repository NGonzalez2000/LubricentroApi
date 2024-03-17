using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Application.Common.Interfaces.Services;
using Lubricentro.Application.EmployeeMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.EmployeeAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.EmployeeMediator.Queries.GetById;

public class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository, IImageService imageService) 
    : IRequestHandler<GetEmployeeByIdQuery, ErrorOr<EmployeeResult>>
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
    private readonly IImageService _imageService = imageService;
    public async Task<ErrorOr<EmployeeResult>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(EmployeeId.Create(request.Id));

        if(employee is null)
        {
            return Errors.Employee.EmployeeNotFound;
        }
        var image = _imageService.GetImage(employee.ImageName);
        return new EmployeeResult(image,
                employee.Id.Value.ToString(), employee.FirstName, employee.LastName, employee.Email,
                employee.User.Role.Id.Value.ToString(), employee.User.Role.Name);
    }
}
