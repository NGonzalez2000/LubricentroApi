using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Lubricentro.Api.Controllers;

public class ErrorsController : ApiController
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    [Route("/error",Name = "Error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (exception == null) return Problem();
        return Problem(exception.GetBaseException().Message);
    }
}
