using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuta.Backend.BuildingBlocks.Infrastructure.Inbox;

namespace Nuta.Backend.Users.Infrastructure.Postgres.Configurations;

public class InboxMessageConfiguration : IEntityTypeConfiguration<InboxMessage>
{
    public void Configure(EntityTypeBuilder<InboxMessage> builder)
    {
        builder.HasKey(inboxMessage => inboxMessage.Id);

        builder.Property(inboxMessage => inboxMessage.Type).IsRequired();
        builder.Property(inboxMessage => inboxMessage.Payload).IsRequired();
        builder.Property(inboxMessage => inboxMessage.Status).IsRequired();
        builder.Property(inboxMessage => inboxMessage.RetryCount).IsRequired();
        builder.Property(inboxMessage => inboxMessage.ReceivedAt).IsRequired();
    }
}