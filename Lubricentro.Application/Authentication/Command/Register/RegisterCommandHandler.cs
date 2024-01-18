using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Authentication;
using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Domain.UserAggregate;
using Lubricentro.Domain.Common.Errors;
using MediatR;
using Lubricentro.Application.Authentication.Common;
using Lubricentro.Domain.EmployeeAggregate.ValueObjects;


namespace Lubricentro.Application.Authentication.Command.Register;

public class RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IUnitOfWork unitOfWork) :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        // Create user (generate unique ID) & Persist to DB
        var user = User.Create(EmployeeId.CreateUnique(), command.Email, command.Password);

        _userRepository.Add(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user.Id.Value.ToString(),
            user.Email,
            token);
    }
}
