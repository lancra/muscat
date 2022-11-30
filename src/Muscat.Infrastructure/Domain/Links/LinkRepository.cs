using Muscat.Core.Links;

namespace Muscat.Infrastructure.Domain.Links;

public class LinkRepository : ILinkRepository
{
    private readonly MuscatDbContext _muscatDbContext;

    public LinkRepository(MuscatDbContext muscatDbContext)
    {
        _muscatDbContext = muscatDbContext;
    }

    public void Add(Link link)
    {
        _muscatDbContext.Add(link);
    }

    public async Task<Link?> Find(LinkId linkId)
        => await _muscatDbContext.Links.FindAsync(linkId)
        .ConfigureAwait(false);
}
