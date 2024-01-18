using ErrorOr;
using Lubricentro.Application.Authentication.Common;
using MediatR;

namespace Lubricentro.Application.Authentication.Command.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
