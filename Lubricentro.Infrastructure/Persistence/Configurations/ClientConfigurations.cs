using Lubricentro.Domain.AddressAggregate;
using Lubricentro.Domain.ClientAggregate;
using Lubricentro.Domain.ClientAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

internal class ClientConfigurations : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        ConfigureClients(builder);
    }

    private static void ConfigureClients(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => ClientId.Create(value));

        builder.HasOne(x => x.Address);

        builder.HasOne(x => x.TaxCondition);

        builder.Property(x => x.ClientName)
            .HasMaxLength(200);

        builder.Property(x => x.Cuil)
            .HasMaxLength(11);

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(x => x.CellphoneNumber)
            .HasMaxLength(20);

        builder.Property(x => x.Email)
            .HasMaxLength(200);

        builder.Property(x => x.Email);

        builder.Property(x => x.HasCheckingAccount);

        builder.Property(x => x.IsWholesaler);

    }
}
