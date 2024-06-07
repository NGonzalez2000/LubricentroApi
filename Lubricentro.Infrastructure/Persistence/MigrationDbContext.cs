using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.MigrationAggregates;
using Lubricentro.Infrastructure.Persistence.Configurations.MigrationConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Lubricentro.Infrastructure.Persistence;

internal class MigrationDbContext(DbContextOptions<MigrationDbContext> options) : DbContext(options)
{
    public DbSet<TaxConditionMigration> TaxConditions { get; set; }
    public DbSet<ClientMigration> Clients { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaxConditionConfigurations());
        modelBuilder.ApplyConfiguration(new ClientConfigurations());

        base.OnModelCreating(modelBuilder);
    }
}
