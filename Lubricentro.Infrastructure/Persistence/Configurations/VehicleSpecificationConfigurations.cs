using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

internal class VehicleSpecificationConfigurations : IEntityTypeConfiguration<VehicleSpecification>
{
    public void Configure(EntityTypeBuilder<VehicleSpecification> builder)
    {
        builder.ToTable("VehicleSpecifications");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => VehicleSpecificationId.Create(value));
    }
}
