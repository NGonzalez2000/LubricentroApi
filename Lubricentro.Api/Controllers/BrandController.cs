using Lubricentro.Application.BrandMediator.Commands.Create;
using Lubricentro.Application.BrandMediator.Commands.Delete;
using Lubricentro.Application.BrandMediator.Commands.Update;
using Lubricentro.Application.BrandMediator.Queries.GetAll;
using Lubricentro.Contracts.Brands;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lubricentro.Api.Controllers;

[Route("[controller]")]
[Authorize(Policy = "BrandPolicy")]
public class BrandController(ISender _mediator, IMapper _mapper) : ApiController
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateBrandRequest request)
    {
        var command = _mapper.Map<CreateBrandCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<BrandResponse>(result)),
            Problem);
    }
    [HttpPost("update")]
    public async Task<IActionResult> Update(UpdateBrandRequest request)
    {
        var command = _mapper.Map<UpdateBrandCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<BrandResponse>(result)),
            Problem);
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(DeleteBrandRequest request)
    {
        var command = _mapper.Map<DeleteBrandCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<BrandResponse>(result)),
            Problem);
    }
    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllBrandsQuery());
        return result.Match(
            result => Ok(_mapper.Map<List<BrandResponse>>(result)),
            Problem);
    }
}
