using Lubricentro.Domain.MigrationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations.MigrationConfigurations;

internal class TaxConditionConfigurations : IEntityTypeConfiguration<TaxConditionMigration>
{
    public void Configure(EntityTypeBuilder<TaxConditionMigration> builder)
    {
        builder.ToTable("TaxConditions");

        builder.HasKey(tc => tc.Id);

        builder.Property(tc => tc.Id)
            .ValueGeneratedNever();

        builder.Property(tc => tc.TaxConditionId);

        builder.Property(tc => tc.Tcl_Codigo);
    }
}
