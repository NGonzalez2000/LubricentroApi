using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;

namespace Lubricentro.Domain.VehicleAggregates;

public class Vehicle : AggregateRoot<VehicleId, Guid>
{
    public string Plate { get; set; }
    public string Year { get; set; }
    public VehicleFactory Factory { get; set; }
    public VehicleModel Model { get; set; }
    public VehicleSpecification Specification { get; set; }
    public string Observation {  get; set; }
    private Vehicle(VehicleId id, string plate, string year, VehicleFactory factory, VehicleModel model, VehicleSpecification specification, string observation) : base(id)
    {
        Plate = plate;
        Year = year;
        Factory = factory;
        Model = model;
        Specification = specification;
        Observation = observation;
    }
    public static Vehicle Create(string plate, string year, VehicleFactory factory, VehicleModel model, VehicleSpecification specification, string observation)
    {
        return new(VehicleId.CreateUnique(), plate, year, factory, model, specification, observation);
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
    private Vehicle() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
}
