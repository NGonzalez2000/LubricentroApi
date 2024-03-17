using Lubricentro.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Lubricentro.Application.Authentication.Queries.Login;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;

namespace Lubricentro.Api.Controllers;

[Route("auth")]
public class AuthenticationController(ISender _mediator, IMapper _mapper) : ApiController
{
    [HttpPost("policyVerification")]
    public IActionResult PolicyVerification(PolicyValidationRequest request)
    {
        PolicyValidationResponse response = new(HttpContext.User.HasClaim(c => c.Type == "Policy" && c.Value == request.PolicyName));
        return Ok(response);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);

        return authResult.Match(
             authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
             Problem
         );
    }
}
