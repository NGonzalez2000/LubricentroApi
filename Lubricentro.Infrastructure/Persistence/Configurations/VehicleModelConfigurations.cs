using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

internal class VehicleModelConfigurations : IEntityTypeConfiguration<VehicleModel>
{
    public void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
        builder.ToTable("VehicleModels");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => VehicleModelId.Create(value));
    }
}
