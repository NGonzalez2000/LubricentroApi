using Lubricentro.Application.VehicleFactoryMediator.Commands.Create;
using Lubricentro.Application.VehicleFactoryMediator.Commands.Delete;
using Lubricentro.Application.VehicleFactoryMediator.Commands.Update;
using Lubricentro.Application.VehicleFactoryMediator.Queries.GetAll;
using Lubricentro.Application.VehicleModelMediator.Commands.Create;
using Lubricentro.Application.VehicleModelMediator.Commands.Delete;
using Lubricentro.Application.VehicleModelMediator.Commands.Update;
using Lubricentro.Application.VehicleModelMediator.Queries.GetAll;
using Lubricentro.Application.VehicleSpecificationMediator.Commands.Create;
using Lubricentro.Application.VehicleSpecificationMediator.Commands.Delete;
using Lubricentro.Application.VehicleSpecificationMediator.Commands.Update;
using Lubricentro.Application.VehicleSpecificationMediator.Queries.GetAll;
using Lubricentro.Contracts.VehicleFactories;
using Lubricentro.Contracts.VehicleModels;
using Lubricentro.Contracts.VehicleSpecification;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lubricentro.Api.Controllers
{


    [Route("[controller]")]
    public class VehicleController(ISender _mediator, IMapper _mapper) : ApiController
    {
        #region VEHICLE
        #endregion
        #region VEHICLE FACTORY

        [HttpGet("factories/getall")]
        public async Task<IActionResult> GetVehicleFactories()
        {
            var result = await _mediator.Send(new GetAllVehicleFactoryQuery());
            return result.Match(
                result => Ok(_mapper.Map<List<VehicleFactoryResponse>>(result)),
                Problem);
        }
        [HttpPost("factories/create")]
        public async Task<IActionResult> CreateVehicleFactory(CreateVehicleFactoryRequest request)
        {
            var command = _mapper.Map<CreateVehicleFactoryCommand>(request);
            var result = await _mediator.Send(command);
            return result.Match(
                result => Ok(_mapper.Map<VehicleFactoryResponse>(result)),
                Problem);
        }
        [HttpPost("factories/update")]
        public async Task<IActionResult> UpdateVehicleFactory(UpdateVehicleFactoryRequest request)
        {
            var command = _mapper.Map<UpdateVehicleFactoryCommand>(request);
            var result = await _mediator.Send(command);
            return result.Match(
               result => Ok(_mapper.Map<VehicleFactoryResponse>(result)),
               Problem);
        }
        [HttpDelete("factories/delete")]
        public async Task<IActionResult> DeleteVehicleFactory(DeleteVehicleFactoryRequest request)
        {
            var command = _mapper.Map<DeleteVehicleFactoryCommand>(request);
            var result = await _mediator.Send(command);
            return result.Match(
               result => Ok(_mapper.Map<VehicleFactoryResponse>(result)),
               Problem);
        }
        #endregion

        #region VEHICLE MODEL

        [HttpGet("models/getall")]
        public async Task<IActionResult> GetVehicleModels()
        {
            var result = await _mediator.Send(new GetAllVehicleModelQuery());
            return result.Match(
                result => Ok(_mapper.Map<List<VehicleModelResponse>>(result)),
                Problem);
        }
        [HttpPost("models/create")]
        public async Task<IActionResult> CreateVehicleModel(CreateVehicleModelRequest request)
        {
            var command = _mapper.Map<CreateVehicleModelCommand>(request);
            var result = await _mediator.Send(command);
            return result.Match(
                result => Ok(_mapper.Map<VehicleModelResponse>(result)),
                Problem);
        }
        [HttpPost("models/update")]
        public async Task<IActionResult> UpdateVehicleModel(UpdateVehicleModelRequest request)
        {
            var command = _mapper.Map<UpdateVehicleModelCommand>(request);
            var result = await _mediator.Send(command);
            return result.Match(
               result => Ok(_mapper.Map<VehicleModelResponse>(result)),
               Problem);
        }
        [HttpDelete("models/delete")]
        public async Task<IActionResult> DeleteVehicleModel(DeleteVehicleModelRequest request)
        {
            var command = _mapper.Map<DeleteVehicleModelCommand>(request);
            var result = await _mediator.Send(command);
            return result.Match(
               result => Ok(_mapper.Map<VehicleModelResponse>(result)),
               Problem);
        }
        #endregion

        #region VEHICLE SPECIFICATION

        [HttpGet("specifications/getall")]
        public async Task<IActionResult> GetVehicleSpecifications()
        {
            var result = await _mediator.Send(new GetAllVehicleSpecificationQuery());
            return result.Match(
                result => Ok(_mapper.Map<List<VehicleSpecificationResponse>>(result)),
                Problem);
        }
        [HttpPost("specifications/create")]
        public async Task<IActionResult> CreateVehicleSpecification(CreateVehicleSpecificationRequest request)
        {
            var command = _mapper.Map<CreateVehicleSpecificationCommand>(request);
            var result = await _mediator.Send(command);
            return result.Match(
                result => Ok(_mapper.Map<VehicleSpecificationResponse>(result)),
                Problem);
        }
        [HttpPost("specifications/update")]
        public async Task<IActionResult> UpdateVehicleSpecification(UpdateVehicleSpecificationRequest request)
        {
            var command = _mapper.Map<UpdateVehicleSpecificationCommand>(request);
            var result = await _mediator.Send(command);
            return result.Match(
               result => Ok(_mapper.Map<VehicleSpecificationResponse>(result)),
               Problem);
        }
        [HttpDelete("specifications/delete")]
        public async Task<IActionResult> DeleteVehicleSpecification(DeleteVehicleSpecificationRequest request)
        {
            var command = _mapper.Map<DeleteVehicleSpecificationCommand>(request);
            var result = await _mediator.Send(command);
            return result.Match(
               result => Ok(_mapper.Map<VehicleSpecificationResponse>(result)),
               Problem);
        }
        #endregion
    }



}
