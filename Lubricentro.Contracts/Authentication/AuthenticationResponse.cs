namespace Lubricentro.Contracts.Authentication;

public record AuthenticationResponse(
    string Id,
    string Email,
    string Token);

