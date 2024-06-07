using ErrorOr;
using Lubricentro.Application.Authentication.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.Common.Interfaces.Services;
using Lubricentro.Domain.Common.Errors;
using MediatR;

namespace Lubricentro.Application.Authentication.Commands.PasswordRecovery;

internal class PasswordRecoveryCommandHandler(IUserProvider _userProvider, IUnitOfWork _unitOfWork) : IRequestHandler<PasswordRecoveryCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(PasswordRecoveryCommand request, CancellationToken cancellationToken)
    {
        var result = await _userProvider.RecoverPasswordAsync(request.UserName);

        if(result is null)
        {
            return Errors.User.NotFound;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new AuthenticationResult("", "", "");
    }
}
