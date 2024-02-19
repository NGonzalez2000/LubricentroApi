using Lubricentro.Domain.PolicyAggregate;
using Lubricentro.Domain.PolicyAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations
{
    internal class PolicyConfigurations : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            ConfigurePermissionTable(builder);
        }

        private void ConfigurePermissionTable(EntityTypeBuilder<Policy> builder)
        {
            builder.ToTable("Policies");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value,
                    id => PolicyId.Create(id));

            builder.Property(p => p.Name)
                .HasMaxLength(100);

        }
    }
}
