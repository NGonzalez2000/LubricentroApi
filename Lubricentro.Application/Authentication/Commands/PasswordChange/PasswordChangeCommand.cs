using ErrorOr;
using Lubricentro.Application.Authentication.Common;
using MediatR;

namespace Lubricentro.Application.Authentication.Commands.PasswordChange;

public record PasswordChangeCommand(string Username, string Password) : IRequest<ErrorOr<AuthenticationResult>>
{
}
