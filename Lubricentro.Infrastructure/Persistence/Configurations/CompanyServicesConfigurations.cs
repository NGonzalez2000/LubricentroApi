using Lubricentro.Domain.CompanyAggregate.Entities;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

internal class CompanyServicesConfigurations : IEntityTypeConfiguration<CompanyService>
{
    public void Configure(EntityTypeBuilder<CompanyService> builder)
    {
        builder.ToTable("CompanyServices");

        builder.HasKey(cs => cs.Id);

        builder.Property(cs => cs.Id)
            .HasConversion(id => id.Value, value => CompanyServiceId.Create(value))
            .ValueGeneratedNever();

        builder.Property(cs => cs.Name);
    }
}
