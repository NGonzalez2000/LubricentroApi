using Lubricentro.Domain.ProductAggregate;
using Lubricentro.Domain.ProductAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

internal class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => ProductId.Create(value));

        builder.Property(x => x.ListPrice)
            .HasPrecision(18, 2);
        builder.Property(x => x.SellPrice)
            .HasPrecision(18, 2);
        builder.Property(x => x.MarkupPercentage)
            .HasPrecision(18, 2);
    }
}
