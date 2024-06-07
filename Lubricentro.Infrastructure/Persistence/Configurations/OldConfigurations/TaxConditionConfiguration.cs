using Lubricentro.Domain.OldAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubricentro.Infrastructure.Persistence.Configurations.OldConfigurations
{
    internal class TaxConditionConfiguration : IEntityTypeConfiguration<OldTaxCondition>
    {
        public void Configure(EntityTypeBuilder<OldTaxCondition> builder)
        {
            builder.ToTable("Cond_Cliente");

            builder.HasNoKey();
        }

    }
}
