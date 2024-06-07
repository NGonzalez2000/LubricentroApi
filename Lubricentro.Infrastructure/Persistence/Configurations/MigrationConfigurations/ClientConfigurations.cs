using Lubricentro.Domain.MigrationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations.MigrationConfigurations;

internal class ClientConfigurations : IEntityTypeConfiguration<ClientMigration>
{
    public void Configure(EntityTypeBuilder<ClientMigration> builder)
    {
        builder.ToTable("Clients");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedNever();

        builder.Property(c => c.ClientId);

        builder.Property(c => c.Cli_Codigo);
    }
}
