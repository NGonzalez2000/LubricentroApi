using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

internal class VehicleFactoryConfigurations : IEntityTypeConfiguration<VehicleFactory>
{
    public void Configure(EntityTypeBuilder<VehicleFactory> builder)
    {
        builder.ToTable("VehicleFactories");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => VehicleFactoryId.Create(value));
    }
}
