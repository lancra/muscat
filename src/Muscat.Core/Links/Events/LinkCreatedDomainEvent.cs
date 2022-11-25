using Muscat.Core.SharedKernel;

namespace Muscat.Core.Links.Events;

public class LinkCreatedDomainEvent : DomainEvent
{
    public LinkCreatedDomainEvent(LinkId linkId)
    {
        LinkId = linkId;
    }

    public LinkId LinkId { get; }
}
