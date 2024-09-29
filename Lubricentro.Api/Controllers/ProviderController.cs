using Lubricentro.Application.ProviderMediator.Command.Create;
using Lubricentro.Application.ProviderMediator.Command.Delete;
using Lubricentro.Application.ProviderMediator.Command.Update;
using Lubricentro.Application.ProviderMediator.Queries;
using Lubricentro.Contracts.Providers;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lubricentro.Api.Controllers;

[Route("[controller]")]
[Authorize(Policy = "ProviderPolicy")]
public class ProviderController(ISender mediator, IMapper mapper) : ApiController
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateProviderRequest request)
    {
        var command = mapper.Map<CreateProviderCommand>(request);
        var result = await mediator.Send(command);
        return result.Match(
            result => Ok(mapper.Map<ProviderResponse>(result)),
            Problem);
    }
    [HttpPost("update")]
    public async Task<IActionResult> Update(UpdateProviderRequest request)
    {
        var command = mapper.Map<UpdateProviderCommand>(request);
        var result = await mediator.Send(command);
        return result.Match(
            result => Ok(mapper.Map<ProviderResponse>(result)),
            Problem);
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(DeleteProviderRequest request)
    {
        var command = mapper.Map<DeleteProviderCommand>(request);
        var result = await mediator.Send(command);
        return result.Match(
            result => Ok(mapper.Map<ProviderResponse>(result)),
            Problem);
    }
    [HttpGet("getall")]
    public async Task<IActionResult> Delete()
    {
        var result = await mediator.Send(new GetAllProvidersQuery());
        return result.Match(
            result => Ok(mapper.Map<List<ProviderResponse>>(result)),
            Problem);
    }
}
