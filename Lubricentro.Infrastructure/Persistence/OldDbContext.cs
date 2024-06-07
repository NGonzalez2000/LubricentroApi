using Lubricentro.Domain.OldAggregates;
using Lubricentro.Infrastructure.Persistence.Configurations.OldConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence;

internal class OldDbContext(DbContextOptions<OldDbContext> options) : DbContext(options)
{
    public DbSet<OldClient> Clients { get; set; }
    public DbSet<OldTaxCondition> TaxConditions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientConfigurations());
        modelBuilder.ApplyConfiguration(new TaxConditionConfiguration());

        base.OnModelCreating(modelBuilder);
    }
    
}
