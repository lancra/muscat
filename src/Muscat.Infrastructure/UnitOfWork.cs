namespace Muscat.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly MuscatDbContext _muscatDbContext;
    private readonly IDomainEventsDispatcher _domainEventsDispatcher;

    public UnitOfWork(MuscatDbContext muscatDbContext, IDomainEventsDispatcher domainEventsDispatcher)
    {
        _muscatDbContext = muscatDbContext;
        _domainEventsDispatcher = domainEventsDispatcher;
    }

    public async Task<int> Commit(CancellationToken cancellationToken)
    {
        await _domainEventsDispatcher.DispatchAll(cancellationToken)
            .ConfigureAwait(false);

        return await _muscatDbContext.SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);
    }
}
