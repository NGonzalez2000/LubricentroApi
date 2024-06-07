using ErrorOr;
using Lubricentro.Application.Authentication.Common;
using MediatR;

namespace Lubricentro.Application.Authentication.Commands.PasswordRecovery;

public record PasswordRecoveryCommand(string UserName) : IRequest<ErrorOr<AuthenticationResult>>
{
}
