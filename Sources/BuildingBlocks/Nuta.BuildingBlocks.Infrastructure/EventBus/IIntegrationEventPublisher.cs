namespace Nuta.BuildingBlocks.Infrastructure.EventBus;

public interface IIntegrationEventPublisher
{
    ValueTask PublishAsync(IntegrationEvent @event, CancellationToken cancellationToken);
}