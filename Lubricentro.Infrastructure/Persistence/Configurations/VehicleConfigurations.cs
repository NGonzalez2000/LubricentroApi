using Lubricentro.Domain.VehicleAggregates;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

internal class VehicleConfigurations : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicles");

        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => VehicleId.Create(value));

        builder.HasIndex(v => v.Plate).IsUnique();
    }
}
