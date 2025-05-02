namespace Nuta.Backend.BuildingBlocks.Infrastructure.EventBus.Interfaces;

public interface IEventBus
{
    Task PublishAsync(IntegrationEvent @event, CancellationToken cancellationToken);
}