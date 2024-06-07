using Lubricentro.Application.TaxConditionMediator.Commands.Create;
using Lubricentro.Application.TaxConditionMediator.Commands.Delete;
using Lubricentro.Application.TaxConditionMediator.Commands.Update;
using Lubricentro.Application.TaxConditionMediator.Queries.GetAll;
using Lubricentro.Contracts.TaxContitions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lubricentro.Api.Controllers;

[Route("[controller]")]
[Authorize(Policy = "ClientPolicy")]
public class TaxConditionController(ISender mediator, IMapper mapster) : ApiController
{
    private readonly ISender _mediator = mediator;
    private readonly IMapper _mapper = mapster;
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateTaxConditionRequest request)
    {
        var command = _mapper.Map<CreateTaxConditionCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<TaxConditionResponse>(result)),
            Problem);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(UpdateTaxConditionRequest request)
    {
        var command = _mapper.Map<UpdateTaxConditionCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<TaxConditionResponse>(result)),
            Problem);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(DeleteTaxConditionRequest request)
    {
        var command = _mapper.Map<DeleteTaxConditionCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<TaxConditionResponse>(result)),
            Problem);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetTaxConditionsQuery());
        return result.Match(
            result => Ok(_mapper.Map<List<TaxConditionResponse>>(result)),
            Problem);
    }

}
