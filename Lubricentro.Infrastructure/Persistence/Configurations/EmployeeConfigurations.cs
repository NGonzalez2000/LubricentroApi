using Lubricentro.Domain.EmployeeAggregate;
using Lubricentro.Domain.EmployeeAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        ConfigureEmployeeTable(builder);
    }

    private static void ConfigureEmployeeTable(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value,
                value => EmployeeId.Create(value));

        builder.Property(e => e.ImageName)
            .HasDefaultValue("person.png");

        builder.Property(e => e.FirstName)
            .HasMaxLength(100);

        builder.Property(e => e.LastName)
            .HasMaxLength(100);

        builder.Property(e => e.Email)
            .HasMaxLength(100);
    }
}
