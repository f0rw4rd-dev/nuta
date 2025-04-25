using Microsoft.Extensions.DependencyInjection;
using Nuta.Backend.BuildingBlocks.Infrastructure.EventBus;

namespace Nuta.Backend.BuildingBlocks.Infrastructure.DependencyInjection;

public static class BuildingBlocksServiceCollectionExtensions
{
    public static IServiceCollection AddBuildingBlocks(this IServiceCollection services)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining<IEventBus>());
        
        services.AddEventBus();

        return services;
    }
}