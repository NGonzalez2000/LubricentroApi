using Lubricentro.Application.ClientMediator.Commands.Create;
using Lubricentro.Application.ClientMediator.Commands.Delete;
using Lubricentro.Application.ClientMediator.Commands.Update;
using Lubricentro.Application.ClientMediator.Queries.GetAll;
using Lubricentro.Contracts.Clients;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lubricentro.Api.Controllers;

[Route("[controller]")]
[Authorize(Policy = "ClientPolicy")]
public class ClientController(ISender _mediator, IMapper _mapper) : ApiController
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateClientRequest request)
    {
        var command = _mapper.Map<CreateClientCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<ClientResponse>(result)),
            Problem);
    }
    [HttpPost("update")]
    public async Task<IActionResult> Update(UpdateClientRequest request)
    {
        var command = _mapper.Map<UpdateClientCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<ClientResponse>(result)),
            Problem);
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(DeleteClientRequest request)
    {
        var command = _mapper.Map<DeleteClientCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<ClientResponse>(result)),
            Problem);
    }
    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetClientsQuery());
        return result.Match(
            result => Ok(_mapper.Map<List<ClientResponse>>(result)),
            Problem);
    }
}
