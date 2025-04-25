using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuta.Backend.BuildingBlocks.Infrastructure.Outbox;

namespace Nuta.Backend.Products.Infrastructure.Persistence.Relational.EntityTypeConfigurations;

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