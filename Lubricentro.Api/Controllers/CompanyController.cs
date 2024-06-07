using Lubricentro.Application.CompanyMediator.Commands.Create;
using Lubricentro.Application.CompanyMediator.Commands.Delete;
using Lubricentro.Application.CompanyMediator.Commands.Update;
using Lubricentro.Application.CompanyMediator.Commands.UpdateServices;
using Lubricentro.Application.CompanyMediator.Queries.GetAll;
using Lubricentro.Application.CompanyMediator.Queries.GetServices;
using Lubricentro.Contracts.Companies;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lubricentro.Api.Controllers;
[Route("[controller]")]
[Authorize(Policy = "CompanyPolicy")]
public class CompanyController(IMapper _mapper, ISender _mediator) : ApiController
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateCompanyRequest request)
    {
        var command = _mapper.Map<CreateCompanyCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<CompanyResponse>(result)),
            Problem);
    }
    [HttpPost("update")]
    public async Task<IActionResult> Update(UpdateCompanyRequest request)
    {
        var command = _mapper.Map<UpdateCompanyCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<CompanyResponse>(result)),
            Problem);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(DeleteCompanyRequest request)
    {
        var command = _mapper.Map<DeleteCompanyCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<CompanyResponse>(result)),
            Problem);
    }


    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCompaniesQuery());
        return result.Match(
            result => Ok(_mapper.Map<List<CompanyResponse>>(result)),
            Problem);
    }
    [HttpGet("getservices")]
    public async Task<IActionResult> GetServices()
    {
        var result = await _mediator.Send(new GetAllCompanyServicesQuery());
        return result.Match(
            result => Ok(_mapper.Map<List<CompanyServiceResponse>>(result)), Problem);
    }
    [HttpPost("updateservices")]
    public async Task<IActionResult> UpdateServices(UpdateCompanyServicesRequest request)
    {
        var command = _mapper.Map<UpdateCompanyServicesCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<List<CompanyServiceResponse>>(result)),Problem);
    }
}
 