using Muscat.Core.Links.Events;
using Muscat.Core.SharedKernel;

namespace Muscat.Core.Links;

public class Link : Entity, IAggregateRoot
{
    private Uri _domain;
    private string _name;
    private DateTime _createdDate;
    private DateTime _modifiedDate;

#pragma warning disable CS8618
    private Link()
#pragma warning restore CS8618
    {
    }

    private Link(Uri domain, string name)
    {
        Id = new(Guid.NewGuid());
        _domain = domain;
        _name = name;
        _createdDate = SystemClock.Now;
        _modifiedDate = _createdDate;

        AddDomainEvent(new LinkCreatedDomainEvent(Id));
    }

    public LinkId Id { get; private set; }

    public static Link CreateNew(Uri domain, string name)
        => new(domain, name);
}
