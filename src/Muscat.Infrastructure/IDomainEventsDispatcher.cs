namespace Muscat.Infrastructure;

/// <summary>
/// Represents the dispatcher for domain events.
/// </summary>
public interface IDomainEventsDispatcher
{
    /// <summary>
    /// Dispatches all domain events.
    /// </summary>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> to observe while waiting for the task to complete.
    /// </param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task DispatchAll(CancellationToken cancellationToken);
}
