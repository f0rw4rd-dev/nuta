using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Nuta.Backend.Access.Infrastructure.Persistence.Relational;
using Nuta.Backend.BuildingBlocks.Infrastructure.EventBus;
using Nuta.Backend.BuildingBlocks.Infrastructure.Outbox;
using Quartz;

namespace Nuta.Backend.Access.Infrastructure.Jobs;

internal class OutboxProcessorJob(AccessModuleDbContext moduleDbContext, IEventBus eventBus) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var messages = await moduleDbContext.Set<OutboxMessage>()
            .Where(x => !x.IsSent)
            .OrderBy(x => x.OccurredAt)
            .Take(20) //todo: make it configurable
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
                //todo: log error
            }
        }

        await moduleDbContext.SaveChangesAsync(context.CancellationToken);
    }
}