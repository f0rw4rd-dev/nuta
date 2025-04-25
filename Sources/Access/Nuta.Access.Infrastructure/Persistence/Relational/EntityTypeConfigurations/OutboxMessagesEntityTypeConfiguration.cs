using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuta.BuildingBlocks.Infrastructure.Outbox;

namespace Nuta.Access.Infrastructure.Persistence.Relational.EntityTypeConfigurations;

public class OutboxMessageEntityTypeConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.HasKey(outboxMessage => outboxMessage.Id);

        builder.Property(outboxMessage => outboxMessage.Type).IsRequired();
        builder.Property(outboxMessage => outboxMessage.Payload).IsRequired();
        builder.Property(outboxMessage => outboxMessage.IsSent).IsRequired();
        builder.Property(outboxMessage => outboxMessage.OccurredAt).IsRequired();
    }
}