using Lubricentro.Domain.EmailAggregates;
using Lubricentro.Domain.EmailAggregates.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

internal class EmailConfigurations : IEntityTypeConfiguration<Email>
{
    public void Configure(EntityTypeBuilder<Email> builder)
    {
        builder.ToTable("Emails");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, value => EmailId.Create(value))
            .ValueGeneratedNever();
    }
}
