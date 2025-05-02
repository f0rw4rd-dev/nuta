using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nuta.Backend.BuildingBlocks.Infrastructure.EventBus;
using Nuta.Backend.BuildingBlocks.Infrastructure.EventBus.Interfaces;
using Nuta.Backend.BuildingBlocks.Infrastructure.Outbox;
using Nuta.Backend.Users.Infrastructure.Postgres;
using Quartz;

namespace Nuta.Backend.Users.Infrastructure.Jobs;

internal class OutboxProcessorJob(
    UsersModuleDbContext dbContext,
    IEventBus eventBus,
    ILogger<OutboxProcessorJob> logger)
    : IJob
{
    private const int BatchSize = 20;

    public async Task Execute(IJobExecutionContext context)
    {
        var messages = await dbContext.Set<OutboxMessage>()
            .Where(x => !x.IsSent)
            .OrderBy(x => x.OccurredAt)
            .Take(BatchSize)
            .ToListAsync(context.CancellationToken);

        foreach (var message in messages)
        {
            try
            {
                var type = Type.GetType(message.Type)!;
                var @event = (IntegrationEvent)JsonSerializer.Deserialize(message.Payload, type)!;

                await eventBus.PublishAsync(@event, context.CancellationToken);

                message.MarkAsSent();
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "Произошла ошибка при обработке сообщения из Outbox: {MessageId}",
                    message.Id);
            }
        }

        await dbContext.SaveChangesAsync(context.CancellationToken);
    }
}