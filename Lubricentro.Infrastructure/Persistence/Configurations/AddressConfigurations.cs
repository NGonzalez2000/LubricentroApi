using Lubricentro.Domain.AddressAggregate;
using Lubricentro.Domain.AddressAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

internal class AddressConfigurations : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        ConfigureAddress(builder);
    }

    private static void ConfigureAddress(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => AddressId.Create(value));

        builder.Property(x => x.Country)
            .HasMaxLength(256);
        builder.Property(x => x.State)
            .HasMaxLength(256);
        builder.Property(x => x.City)
            .HasMaxLength(256);
        builder.Property(x => x.Street)
            .HasMaxLength(256);
        builder.Property(x => x.PostalCode)
            .HasMaxLength(256);

    }
}
