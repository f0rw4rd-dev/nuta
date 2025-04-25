using Microsoft.Extensions.DependencyInjection;
using Nuta.BuildingBlocks.Infrastructure.EventBus;

namespace Nuta.BuildingBlocks.Infrastructure.DependencyInjection;

public static class BuildingBlocksServiceCollectionExtensions
{
    public static IServiceCollection AddBuildingBlocks(this IServiceCollection services)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining<IEventBus>());
        
        services.AddEventBus();

        return services;
    }
}