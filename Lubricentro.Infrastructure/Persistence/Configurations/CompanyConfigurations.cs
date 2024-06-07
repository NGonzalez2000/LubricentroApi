using Lubricentro.Domain.CompanyAggregate;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

internal class CompanyConfigurations : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        ConfigureCompanies(builder);
    }

    private static void ConfigureCompanies(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => CompanyId.Create(value));

        builder.Property(c => c.Name)
            .HasMaxLength(50);
        builder.Property(c => c.Cuil);
        builder.Property(c => c.Email);
        builder.Property(c => c.Password);
    }
}
