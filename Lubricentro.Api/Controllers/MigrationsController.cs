using ErrorOr;
using Lubricentro.Application.MigrationMediator.ClientMediator.Commands.Create;
using Lubricentro.Application.MigrationMediator.ClientMediator.Commands.Update;
using Lubricentro.Application.MigrationMediator.ClientMediator.Queries;
using Lubricentro.Application.MigrationMediator.TaxConditionMediator.Commands.Create;
using Lubricentro.Application.MigrationMediator.TaxConditionMediator.Commands.Update;
using Lubricentro.Application.MigrationMediator.TaxConditionMediator.Common;
using Lubricentro.Application.MigrationMediator.TaxConditionMediator.Queries;
using Lubricentro.Contracts.Clients;
using Lubricentro.Contracts.Migrations.Client;
using Lubricentro.Contracts.Migrations.TaxCondition;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lubricentro.Api.Controllers;

[Route("[controller]")]
[Authorize(Policy = "MigrationPolicy")]
public class MigrationsController(IMapper _mapper, ISender _mediator) : ApiController
{
    [HttpGet("clients")]
    public async Task<IActionResult> GetClientsAsync()
    {
        var result = await _mediator.Send(new GetAllOldClientsQuery());
        return result.Match(
            result => Ok(_mapper.Map<List<OldClientResponse>>(result)),
            Problem);
    }



    [HttpPost("clients/create")]
    public async Task<IActionResult> CreateClient(CreateClientMigrationRequest request)
    {
        var command = _mapper.Map<CreateClientMigrationCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(result => Ok(_mapper.Map<ClientResponse>(result)), Problem);
    }



    [HttpPost("clients/update")]
    public async Task<IActionResult> UpdateClient(UpdateClientMigrationRequest request)
    {
        var command = _mapper.Map<UpdateClientMigrationCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(result => Ok(_mapper.Map<ClientResponse>(result)), Problem);
    }



    [HttpGet("taxconditions")]
    public async Task<IActionResult> GetTaxConditionsAsync()
    {
        var result = await _mediator.Send(new GetAllOldTaxConditionsQuery());
        return result.Match(
            result => Ok(_mapper.Map<List<OldTaxConditionResponse>>(result)),
            Problem);
    }

    [HttpPost("taxconditions/create")]
    public async Task<IActionResult> CreateTaxCondition(CreateTaxConditionMigrationRequest request)
    {
        var command = _mapper.Map<CreateTaxConditionMigrationCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(result => Ok(_mapper.Map<TaxConditionMigrationResponse>(result)), Problem);
    }

    [HttpPost("taxconditions/update")]
    public async Task<IActionResult> UpdateTaxCondition(UpdateTaxConditionMigrationRequest request)
    {
        var command = _mapper.Map<UpdateTaxConditionMigrationCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(result => Ok(_mapper.Map<TaxConditionMigrationResponse>(result)), Problem);
    }
}
