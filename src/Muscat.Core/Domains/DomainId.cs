using Muscat.Core.SharedKernel;

namespace Muscat.Core.Domains;

public class DomainId : StronglyTypedId
{
    public DomainId(Guid value)
        : base(value)
    {
    }
}
