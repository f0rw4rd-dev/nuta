namespace Nuta.BuildingBlocks.Infrastructure.EventBus;

public interface IEventBus
{
    Task PublishAsync(IntegrationEvent @event, CancellationToken cancellationToken);
}