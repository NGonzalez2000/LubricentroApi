using Lubricentro.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Lubricentro.Application.Authentication.Queries.Login;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;

namespace Lubricentro.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController(ISender _mediator, IMapper _mapper) : ApiController
{

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
