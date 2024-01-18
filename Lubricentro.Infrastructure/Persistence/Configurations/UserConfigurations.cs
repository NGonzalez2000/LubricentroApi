using Lubricentro.Domain.EmployeeAggregate.ValueObjects;
using Lubricentro.Domain.UserAggregate;
using Lubricentro.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUserTable(builder);
    }

    private void ConfigureUserTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.Property(u => u.Email)
            .HasMaxLength(100);

        builder.Property(u => u.Password)
            .HasMaxLength(100);

        builder.Property(u => u.EmployeeId)
            .HasConversion(
                id => id.Value,
                value => EmployeeId.Create(value));
    }
}
