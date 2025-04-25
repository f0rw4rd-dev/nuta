using System.Text.Json;
using MediatR;
using Nuta.Backend.BuildingBlocks.Infrastructure.EventBus;
using Nuta.Backend.BuildingBlocks.Infrastructure.Inbox;
using Nuta.Backend.Users.Infrastructure.Persistence.Relational;

namespace Nuta.Backend.Users.Infrastructure.PipelineBehaviors;

internal class InboxPipelineBehaviour<TRequest, TResponse>(UsersModuleDbContext moduleDbContext)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IntegrationEvent
{
    private const int MaxRetryCount = 3; //todo: make it configurable
    
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var inboxMessage = await moduleDbContext.InboxMessages.FindAsync([request.Id], cancellationToken);

        if (inboxMessage is { Status: InboxMessageStatus.Processed })
            return default!;

        if (inboxMessage is null)
        {
            moduleDbContext.InboxMessages.Add(
                new InboxMessage(
                    request.GetType().AssemblyQualifiedName!,
                    JsonSerializer.Serialize(request)));
            
            await moduleDbContext.SaveChangesAsync(cancellationToken);
        }

        try
        {
            inboxMessage!.MarkAsProcessed();
            await moduleDbContext.SaveChangesAsync(cancellationToken);
            
            return await next(cancellationToken);
        }
        catch (Exception ex)
        {
            inboxMessage!.IncrementRetryCount();
            await moduleDbContext.SaveChangesAsync(cancellationToken);

            if (inboxMessage.RetryCount >= MaxRetryCount)
                throw;

            throw; //todo: InboxRetryNeededException
        }
    }
}