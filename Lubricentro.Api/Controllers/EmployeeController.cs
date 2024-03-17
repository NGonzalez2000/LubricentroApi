using Lubricentro.Application.EmployeeMediator.Command.Create;
using Lubricentro.Application.EmployeeMediator.Command.Delete;
using Lubricentro.Application.EmployeeMediator.Command.Update;
using Lubricentro.Application.EmployeeMediator.Queries.GetAll;
using Lubricentro.Application.EmployeeMediator.Queries.GetById;
using Lubricentro.Contracts.Employees;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lubricentro.Api.Controllers;

[Route("[controller]")]
[Authorize(Policy = "EmployeeModificationsPolicy")]

public class EmployeeController(IMapper _mapper, ISender _mediator) : ApiController
{
    [HttpGet("getall")]
    public async Task<IActionResult> GetEmployees()
    {
        var result = await _mediator.Send(new GetEmployeesQuery());
        return result.Match(
            result => Ok(_mapper.Map<List<EmployeeResponse>>(result)),
            Problem);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateEmployeeRequest request)
    {
        var command = _mapper.Map<CreateEmployeeCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<EmployeeResponse>(result)),
            Problem);
    }
    [HttpPost("update")]
    public async Task<IActionResult> Update(UpdateEmployeeRequest request)
    {
        var command = _mapper.Map<UpdateEmployeeCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<EmployeeResponse>(result)),
            Problem);
    }

    [HttpPost("getbyid")]
    public async Task<IActionResult> GetById(GetEmployeeByIdRequest request)
    {
        var query = _mapper.Map<GetEmployeeByIdQuery>(request);
        var result = await _mediator.Send(query);
        return result.Match(
            result => Ok(_mapper.Map<EmployeeResponse>(result)),
            Problem
            );
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(DeleteEmployeeRequest request)
    {
        var query = _mapper.Map<DeleteEmployeeCommand>(request);
        var result = await _mediator.Send(query);
        return result.Match(
            result => Ok(_mapper.Map<EmployeeResponse>(result)),
            Problem
            );
    }
}

