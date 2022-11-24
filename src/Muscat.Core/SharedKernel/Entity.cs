namespace Muscat.Core.SharedKernel;

public abstract class Entity
{
    private List<IDomainEvent>? _domainEvents;

    public IReadOnlyCollection<IDomainEvent> DomainEvents => (_domainEvents ?? new List<IDomainEvent>()).AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents ??= new List<IDomainEvent>();
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
        => _domainEvents?.Clear();
}
