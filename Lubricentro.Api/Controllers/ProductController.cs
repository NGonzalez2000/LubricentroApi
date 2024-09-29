using Lubricentro.Application.ProductMediator.Command.Create;
using Lubricentro.Application.ProductMediator.Command.Delete;
using Lubricentro.Application.ProductMediator.Command.Update;
using Lubricentro.Application.ProductMediator.Queries.GetAll;
using Lubricentro.Contracts.Products;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lubricentro.Api.Controllers;

[Route("[controller]")]
public class ProductController(ISender _mediator, IMapper _mapper) : ApiController
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllProductQuery());
        return result.Match(
            result => Ok(_mapper.Map<List<ProductResponse>>(result)),
            Problem);
    }
    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateProductRequest request)
    {
        var command = _mapper.Map<CreateProductCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(result => Ok(_mapper.Map<ProductResponse>(result)),
            Problem);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> Update(UpdateProductRequest request)
    {
        var command = _mapper.Map<UpdateProductCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(result => Ok(_mapper.Map<ProductResponse>(result)),
            Problem);
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(DeleteProductRequest request)
    {
        var command = _mapper.Map<DeleteProductCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(result => Ok(_mapper.Map<ProductResponse>(result)),
            Problem);
    }
}
