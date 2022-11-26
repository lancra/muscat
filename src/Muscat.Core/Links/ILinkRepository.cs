namespace Muscat.Core.Links;

/// <summary>
/// Represents the data repository for links.
/// </summary>
public interface ILinkRepository
{
    /// <summary>
    /// Adds a link.
    /// </summary>
    /// <param name="link">The link to add.</param>
    void Add(Link link);

    /// <summary>
    /// Finds a link using an identifier.
    /// </summary>
    /// <param name="linkId">The identifier of the link to find.</param>
    /// <returns>The matching matching link if it is found; otherwise, <c>null</c>.</returns>
    Task<Link?> FindAsync(LinkId linkId);
}
