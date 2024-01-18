using Lubricentro.Application.EmployeeMediator.Command.Create;
using Lubricentro.Application.EmployeeMediator.Queries.GetById;
using Lubricentro.Contracts.Employees;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lubricentro.Api.Controllers;

[Route("[controller]")]
public class EmployeeController(IMapper _mapper, ISender _mediator) : ApiController
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateEmployeeRequest request)
    {
        var command = _mapper.Map<CreateCommand>(request);
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
            Problem);
    }
}

