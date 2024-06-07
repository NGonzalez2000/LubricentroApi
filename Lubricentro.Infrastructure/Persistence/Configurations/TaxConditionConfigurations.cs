using Lubricentro.Domain.TaxConditionAggregate;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

internal class TaxConditionConfigurations : IEntityTypeConfiguration<TaxCondition>
{
    public void Configure(EntityTypeBuilder<TaxCondition> builder)
    {
        ConfigureTaxCondition(builder);
    }

    private void ConfigureTaxCondition(EntityTypeBuilder<TaxCondition> builder)
    {
        builder.ToTable("TaxConditions");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedNever()
            .HasConversion(Id => Id.Value, value => TaxConditionId.Create(value));

        builder.Property(t => t.Description)
            .HasMaxLength(100);

        builder.Property(t => t.Type);

        builder.Property(t => t.VAT);
    }
}
