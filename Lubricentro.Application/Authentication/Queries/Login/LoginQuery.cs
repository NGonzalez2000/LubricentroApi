using ErrorOr;
using Lubricentro.Application.Authentication.Common;
using MediatR;

namespace Lubricentro.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
