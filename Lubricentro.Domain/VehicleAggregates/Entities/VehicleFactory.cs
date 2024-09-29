using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;

namespace Lubricentro.Domain.VehicleAggregates.Entities;

public class VehicleFactory : AggregateRoot<VehicleFactoryId, Guid>
{
    public string Name { get; set; }
    public List<VehicleModel> Models { get; set; }
    private VehicleFactory(VehicleFactoryId id, string name) : base(id)
    {
        Name = name;
        Models = [VehicleModel.Create("SIN MODELO", true)];
    }
    public void Update(string name)
    {
        Name = name;
    }
    public void AddVehicleModel(VehicleModel model)
    {
        Models.Add(model);
    }
    public static VehicleFactory Create(string name)
    {
        return new(VehicleFactoryId.CreateUnique(), name);
    }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
    private VehicleFactory() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
}
