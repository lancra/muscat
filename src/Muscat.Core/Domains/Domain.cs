using Muscat.Core.Domains.Events;
using Muscat.Core.SharedKernel;

namespace Muscat.Core.Domains;

public class Domain : Entity, IAggregateRoot
{
    private Uri _uri;
    private string _name;
    private DateTime _createdDate;
    private DateTime _modifiedDate;

#pragma warning disable CS8618
    private Domain()
#pragma warning restore CS8618
    {
    }

    private Domain(Uri uri, string name)
    {
        Id = new(Guid.NewGuid());
        _uri = uri;
        _name = name;
        _createdDate = SystemClock.Now;
        _modifiedDate = _createdDate;

        AddDomainEvent(new DomainCreatedDomainEvent(Id));
    }

    public DomainId Id { get; private set; }

    public static Domain CreateNew(Uri uri, string name)
        => new(uri, name);
}
