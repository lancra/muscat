using Muscat.Core.Domains;

namespace Muscat.Infrastructure.Core.Domains;

public class DomainRepository : IDomainRepository
{
    private readonly MuscatDbContext _muscatDbContext;

    public DomainRepository(MuscatDbContext muscatDbContext)
    {
        _muscatDbContext = muscatDbContext;
    }

    public void Add(Domain domain)
    {
        _muscatDbContext.Add(domain);
    }

    public async Task<Domain?> Find(DomainId domainId)
        => await _muscatDbContext.Domains.FindAsync(domainId)
        .ConfigureAwait(false);
}
