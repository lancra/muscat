namespace Muscat.Core.Domains;

/// <summary>
/// Represents the data repository for domains.
/// </summary>
public interface IDomainRepository
{
    /// <summary>
    /// Adds a domain.
    /// </summary>
    /// <param name="domain">The domain to add.</param>
    void Add(Domain domain);

    /// <summary>
    /// Finds a domain using an identifier.
    /// </summary>
    /// <param name="domainId">The identifier of the domain to find.</param>
    /// <returns>
    /// The <see cref="Task"/> that represents the asynchronous operation,
    /// containing the matching matching domain if it is found; otherwise, <c>null</c>.
    /// </returns>
    Task<Domain?> Find(DomainId domainId);
}
