using ErrorOr;
using Lubricentro.Application.Authentication.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.Common.Errors;
using MediatR;

namespace Lubricentro.Application.Authentication.Commands.PasswordChange;

internal class PasswordChangeCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : IRequestHandler<PasswordChangeCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(PasswordChangeCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByEmail(request.Username);
        if (user is null)
        {
            return Errors.User.NotFound;
        }

        user.NewPassword(request.Password);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AuthenticationResult("", "", "");
    }
}
