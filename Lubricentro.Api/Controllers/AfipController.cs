using Microsoft.AspNetCore.Mvc;

namespace Lubricentro.Api.Controllers;
[Route("[controller]")]
public class AfipController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        await Task.CompletedTask;
        return Ok();
    }
}
