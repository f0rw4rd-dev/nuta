using MediatR;

namespace Nuta.BuildingBlocks.Infrastructure.EventBus;

public class EventBus(IMediator mediator) : IEventBus
{
    public async Task PublishAsync(IntegrationEvent @event, CancellationToken cancellationToken)
    {
        await mediator.Publish(@event, cancellationToken);
    }
}