using Autofac;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Muscat.Core.SharedKernel;

namespace Muscat.Infrastructure;

public class DomainEventsDispatcher : IDomainEventsDispatcher
{
    private readonly IMediator _mediator;
    private readonly MuscatDbContext _muscatDbContext;

    public DomainEventsDispatcher(IMediator mediator, MuscatDbContext muscatDbContext)
    {
        _mediator = mediator;
        _muscatDbContext = muscatDbContext;
    }

    public async Task DispatchAll(CancellationToken cancellationToken)
    {
        var domainEvents = GetAll();
        ClearAll();

        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent, cancellationToken)
                .ConfigureAwait(false);
        }
    }

    private IReadOnlyCollection<IDomainEvent> GetAll()
        => GetAllEntities()
        .SelectMany(domainEntity => domainEntity.Entity.DomainEvents)
        .ToArray();

    private void ClearAll()
    {
        var domainEntities = GetAllEntities();
        foreach (var domainEntity in domainEntities)
        {
            domainEntity.Entity.ClearDomainEvents();
        }
    }

    private IReadOnlyCollection<EntityEntry<Entity>> GetAllEntities()
        => _muscatDbContext.ChangeTracker.Entries<Entity>()
        .Where(entry => entry.Entity.DomainEvents is not null && entry.Entity.DomainEvents.Any())
        .ToArray();
}
