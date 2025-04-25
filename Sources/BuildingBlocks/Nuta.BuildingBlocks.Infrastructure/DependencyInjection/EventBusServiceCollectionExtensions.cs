using Microsoft.Extensions.DependencyInjection;
using Nuta.BuildingBlocks.Infrastructure.EventBus;

namespace Nuta.BuildingBlocks.Infrastructure.DependencyInjection;

internal static class EventBusServiceCollectionExtensions
{
    public static IServiceCollection AddEventBus(this IServiceCollection services)
    {
        services.AddScoped<IEventBus, EventBus.EventBus>();

        return services;
    }
}