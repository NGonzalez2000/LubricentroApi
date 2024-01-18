namespace Lubricentro.Application.Authentication.Common;

public record AuthenticationResult(
    string Id,
    string Email,
    string Token);
