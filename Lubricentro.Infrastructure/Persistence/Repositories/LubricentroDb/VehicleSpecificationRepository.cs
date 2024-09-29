using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb;

internal class VehicleSpecificationRepository(LubricentroDbContext dbContext) : Repository<VehicleSpecification, VehicleSpecificationId>(dbContext), IVehicleSpecificationRepository
{
    public async Task<IEnumerable<VehicleSpecification>> GetAllVehicleSpecifiationsAsync()
    {
        return await DbContext.VehicleSpecifications.ToListAsync();
    }

    public VehicleSpecification? GetVehicleSpecificationById(VehicleSpecificationId id)
    {
        return DbContext.VehicleSpecifications.SingleOrDefault(vs => vs.Id == id);
    }

    public bool LookUp(string Specifiaction, VehicleSpecificationId? id = null)
    {
        return id is null ? 
            DbContext.VehicleSpecifications.Any(vs => vs.Specification == Specifiaction) :
            DbContext.VehicleSpecifications.Any(vs => vs.Specification == Specifiaction && vs.Id != id);
    }
}
