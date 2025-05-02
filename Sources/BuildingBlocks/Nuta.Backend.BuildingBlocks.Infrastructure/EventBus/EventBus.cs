using MediatR;
using Nuta.Backend.BuildingBlocks.Infrastructure.EventBus.Interfaces;

namespace Nuta.Backend.BuildingBlocks.Infrastructure.EventBus;

public class EventBus(IMediator mediator) : IEventBus
{
    public async Task PublishAsync(IntegrationEvent @event, CancellationToken cancellationToken)
    {
        await mediator.Publish(@event, cancellationToken);
    }
}