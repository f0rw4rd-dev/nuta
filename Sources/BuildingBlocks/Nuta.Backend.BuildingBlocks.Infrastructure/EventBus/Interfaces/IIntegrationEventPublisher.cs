namespace Nuta.Backend.BuildingBlocks.Infrastructure.EventBus.Interfaces;

public interface IIntegrationEventPublisher
{
    ValueTask PublishAsync(IntegrationEvent @event, CancellationToken cancellationToken);
}