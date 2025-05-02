using Nuta.Backend.Users.Infrastructure.Postgres;
using Quartz;

namespace Nuta.Backend.Users.Infrastructure.Jobs;

public class InboxProcessorJob(UsersModuleDbContext dbContext) : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        return Task.CompletedTask;
    }
}