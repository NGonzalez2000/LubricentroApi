using Lubricentro.Domain.ChatMessageAggregate;
using Lubricentro.Domain.ChatMessageAggregate.ValueObjects;
using Lubricentro.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lubricentro.Infrastructure.Persistence.Configurations;

internal class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
{
    public void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
        ConfigureChatMessages(builder);
    }

    private static void ConfigureChatMessages(EntityTypeBuilder<ChatMessage> builder)
    {
        builder.ToTable("ChatMessages");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => ChatMessageId.Create(value));

        builder.Property(x => x.SenderId) 
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => UserId.Create(value));

        builder.Property(x => x.ReceptorId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => UserId.Create(value));

        builder.Property(x => x.MessageText);

        builder.Property(x => x.DateTime)
            .HasColumnName("TimeSend");
    }
}
