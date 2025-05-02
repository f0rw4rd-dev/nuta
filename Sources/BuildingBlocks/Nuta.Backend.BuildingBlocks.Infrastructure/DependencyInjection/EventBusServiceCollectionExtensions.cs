using Microsoft.Extensions.DependencyInjection;
using Nuta.Backend.BuildingBlocks.Infrastructure.EventBus;
using Nuta.Backend.BuildingBlocks.Infrastructure.EventBus.Interfaces;

namespace Nuta.Backend.BuildingBlocks.Infrastructure.DependencyInjection;

internal static class EventBusServiceCollectionExtensions
{
    public static IServiceCollection AddEventBus(this IServiceCollection services)
    {
        services.AddScoped<IEventBus, EventBus.EventBus>();

        return services;
    }
}