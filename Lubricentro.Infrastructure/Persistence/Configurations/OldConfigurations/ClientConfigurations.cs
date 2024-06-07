using Lubricentro.Domain.OldAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations.OldConfigurations;

internal class ClientConfigurations : IEntityTypeConfiguration<OldClient>
{
    public void Configure(EntityTypeBuilder<OldClient> builder)
    {
        builder.ToTable("Clientes");

        builder.HasNoKey();
    }
}
