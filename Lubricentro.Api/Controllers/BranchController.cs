using Lubricentro.Application.BranchMediator.Commands.Create;
using Lubricentro.Application.BranchMediator.Commands.Delete;
using Lubricentro.Application.BranchMediator.Commands.Update;
using Lubricentro.Application.BranchMediator.Queries.GetAll;
using Lubricentro.Application.BranchMediator.Queries.GetByCompanyId;
using Lubricentro.Contracts.Branchs;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lubricentro.Api.Controllers;

[Route("[controller]")]
[Authorize(Policy = "CompanyPolicy")]
public class BranchController(IMapper _mapper, ISender _mediator) : ApiController
{
    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<IActionResult> GetBranches()
    {
        var query = new GetAllBranchQuery();
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(_mapper.Map<List<BranchResponse>>(result)),
            Problem);
    }

    [HttpPost("GetByCompanyId")]
    public async Task<IActionResult> GetCompanyBranches(GetCompanyBranchesRequest request)
    {
        var command = _mapper.Map<GetByCompanyIdBranchQuery>(request);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(_mapper.Map<List<BranchResponse>>(result)),
            Problem);
    }
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateBranchRequest request)
    {
        var command = _mapper.Map<CreateBranchCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(_mapper.Map<BranchResponse>(result)),
            Problem);
    }
    [HttpPost("update")]
    public async Task<IActionResult> Update(UpdateBranchRequest request)
    {
        var command = _mapper.Map<UpdateBranchCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(_mapper.Map<BranchResponse>(result)),
            Problem);
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(DeleteBranchRequest request)
    {
        var command = _mapper.Map<DeleteBranchCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(_mapper.Map<BranchResponse>(result)),
            Problem);
    }
}
