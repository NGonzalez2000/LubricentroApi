using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;

namespace Lubricentro.Domain.VehicleAggregates.Entities;

public class VehicleSpecification : AggregateRoot<VehicleSpecificationId, Guid>
{
    public string Specification { get; set; }
    private VehicleSpecification(VehicleSpecificationId id, string specification) : base(id)
    {
        Specification = specification;
    }
    public void Update(string specification)
    {
        Specification = specification;
    }
    public static VehicleSpecification Create(string specification)
    {
        return new(VehicleSpecificationId.CreateUnique(), specification);
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
    private VehicleSpecification() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
}
