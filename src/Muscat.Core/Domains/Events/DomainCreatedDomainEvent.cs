using Muscat.Core.SharedKernel;

namespace Muscat.Core.Domains.Events;

public class DomainCreatedDomainEvent : DomainEvent
{
    public DomainCreatedDomainEvent(DomainId domainId)
    {
        DomainId = domainId;
    }

    public DomainId DomainId { get; }
}
