using Lubricentro.Application.ChatMediator.Command.GetConversation;
using Lubricentro.Application.ChatMediator.Queries;
using Lubricentro.Contracts.Hubs.Chat;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lubricentro.Api.Controllers;
[Route("[controller]")]
[Authorize(Policy = "ChatPolicy")]
public class ChatController(IMapper mapper, ISender mediator) : ApiController
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;
    [HttpGet("getusers")]
    public async Task<IActionResult> GetUsers()
    {
        if (HttpContext.User.Identity is not ClaimsIdentity claimsIdentity)
        {
            // No claims available, handle the error
            return BadRequest("No claims available");
        }
        var claim = claimsIdentity.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);
        var result = await _mediator.Send(new GetUsersQuery(claim!.Value));
        return result.Match(result => Ok(_mapper.Map<IEnumerable<ChatUserResponse>>(result) ),Problem);
    }

    [HttpPost("getconversation")]
    public async Task<IActionResult> GetConversation(GetConversationRequest request)
    {
        var command = _mapper.Map<GetConversationCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(_mapper.Map<List<ChatMessageResponse>>(result)),
            Problem);
    }
}
