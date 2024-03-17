using Lubricentro.Application.RoleMediator.Command.Create;
using Lubricentro.Application.RoleMediator.Command.Delete;
using Lubricentro.Application.RoleMediator.Command.Update;
using Lubricentro.Application.RoleMediator.Queries.GetAll;
using Lubricentro.Application.RoleMediator.Queries.GetAllPolicies;
using Lubricentro.Contracts.Roles;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lubricentro.Api.Controllers;
[Route("[controller]")]
public class RoleController(IMapper mapper, ISender sender) : ApiController
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = sender;
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateRoleRequest request)
    {
        var command = _mapper.Map<CreateRoleCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(result => Ok(_mapper.Map<RoleResponse>(result)),
            Problem);
    }
    [HttpPost("update")]
    public async Task<IActionResult> Update(UpdateRoleRequest request)
    {
        var command = _mapper.Map<UpdateRoleCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(result => Ok(_mapper.Map<RoleResponse>(result)),
            Problem);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteRoleRequest request)
    {
        var command = _mapper.Map<DeleteRoleCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(result => Ok(_mapper.Map<RoleResponse>(result)),
            Problem);
    }
    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllRolesQuery());
        return result.Match(result => Ok(_mapper.Map<List<RoleResponse>>(result)),
            Problem);
    }

    [HttpGet("getallpolicies")]
    public async Task<IActionResult> GetAllPolicies()
    {
        var result = await _mediator.Send(new GetAllPoliciesQuery());
        return result.Match(result => Ok(_mapper.Map<List<PolicyResponse>>(result)), Problem);
    }
}

