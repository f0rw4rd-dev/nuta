using System.Text.Json;
using MediatR;
using Nuta.Backend.BuildingBlocks.Infrastructure.EventBus;
using Nuta.Backend.BuildingBlocks.Infrastructure.Inbox;
using Nuta.Backend.Users.Infrastructure.Postgres;

namespace Nuta.Backend.Users.Infrastructure.PipelineBehaviors;

internal class InboxPipelineBehaviour<TRequest, TResponse>(UsersModuleDbContext dbContext)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IntegrationEvent
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var inboxMessage = await dbContext.InboxMessages.FindAsync([request.Id], cancellationToken);

        if (inboxMessage is not null)
            return await next(cancellationToken);

        dbContext.InboxMessages.Add(
            new InboxMessage(
                type: request.GetType().AssemblyQualifiedName!,
                payload: JsonSerializer.Serialize(request)));

        await dbContext.SaveChangesAsync(cancellationToken);

        return await next(cancellationToken);
    }
}