namespace Muscat.Core.SharedKernel;

public abstract class DomainEvent : IDomainEvent
{
    public Guid Id { get; } = Guid.NewGuid();

    public DateTime DateOccurred { get; } = SystemClock.Now;
}
