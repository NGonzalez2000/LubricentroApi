using Lubricentro.Domain.PhoneAggregate;
using Lubricentro.Domain.PhoneAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

internal class PhoneConfigurations : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder.ToTable("Phones");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, value => PhoneId.Create(value));
    }
}
