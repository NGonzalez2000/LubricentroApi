using Lubricentro.Contracts.Hubs.Chat;
using Microsoft.AspNetCore.Mvc;

namespace Lubricentro.Api.Controllers;

public class ChatController() : ApiController
{
    [HttpPost("join")]
    public IActionResult JoinChat(JoinChatRequest request)
    {
        
        return Ok();
    }
}
