using Lubricentro.Domain.CompanyAggregate.Entities;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

internal class StockItemLocationConfigurations : IEntityTypeConfiguration<StockItemLocation>
{
    public void Configure(EntityTypeBuilder<StockItemLocation> builder)
    {
        builder.ToTable("StockItemLocantions");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => StockItemLocationId.Create(value));
    }
}
