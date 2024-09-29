using Lubricentro.Domain.CompanyAggregate.Entities;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

internal class BranchConfigurations : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("Branches");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => BranchId.Create(value));
    }
}
