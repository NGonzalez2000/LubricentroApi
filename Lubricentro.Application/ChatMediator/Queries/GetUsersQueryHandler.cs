using ErrorOr;
using Lubricentro.Application.ChatMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.Common.Interfaces.Services;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.ChatMediator.Queries;

public class GetUsersQueryHandler(IUserRepository userRepository, IEmployeeRepository employeeRepository, IImageService imageService) : IRequestHandler<GetUsersQuery, ErrorOr<List<UserResult>>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
    private readonly IImageService _imageService = imageService;
    public async Task<ErrorOr<List<UserResult>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        UserId userId = UserId.Create(new Guid(request.Id));
        if(await _userRepository.GetUserByIdAsync(userId) is null)
        {
            return Errors.User.NotFound;
        }

        var employees = await _employeeRepository.GetAll();

        if(employees is null)
        {
            return new List<UserResult>();
        }

        List<UserResult> userResults = [];

        foreach(var employee in employees)
        {
            if(employee.User.Id != userId)
            userResults.Add(new(_imageService.GetImage(employee.ImageName),employee.User.Id.Value.ToString(),$"{employee.FirstName} {employee.LastName}"));
        }
        return userResults;
    }
}
