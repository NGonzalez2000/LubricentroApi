using Lubricentro.Domain.PermissionAggregate;
using Lubricentro.Domain.PermissionAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations
{
    internal class PermissionConfigurations : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            ConfigurePermissionTable(builder);
        }

        private void ConfigurePermissionTable(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value,
                    id => PermissionId.Create(id));

            builder.Property(p => p.Name)
                .HasMaxLength(100);

        }
    }
}
