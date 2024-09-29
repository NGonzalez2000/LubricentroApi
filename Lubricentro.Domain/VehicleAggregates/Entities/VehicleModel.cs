using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;

namespace Lubricentro.Domain.VehicleAggregates.Entities;

public class VehicleModel : AggregateRoot<VehicleModelId, Guid>
{
    public string Name {  get; set; }
    public bool IsLight { get; set; }
    private VehicleModel(VehicleModelId id, string name, bool isLight) : base(id)
    {
        Name = name;
        IsLight = isLight;
    }
    public void Update(string name, bool isLight)
    {
        Name = name;
        IsLight = isLight;
    }
    public static VehicleModel Create(string name, bool isLight)
    {
        return new(VehicleModelId.CreateUnique(), name, isLight);
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
    private VehicleModel() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
}
