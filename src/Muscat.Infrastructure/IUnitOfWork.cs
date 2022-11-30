namespace Muscat.Infrastructure;

/// <summary>
/// Represents one or more database operations that are operated on as a single unit.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Commits the unit.
    /// </summary>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> to observe while waiting for the task to complete.
    /// </param>
    /// <returns>
    /// The <see cref="Task"/> that represents the asynchronous operation,
    /// containing the number of state entries written to the database.
    /// </returns>
    Task<int> Commit(CancellationToken cancellationToken);
}
