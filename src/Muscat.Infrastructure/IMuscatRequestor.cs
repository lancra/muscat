using Muscat.Application;

namespace Muscat.Infrastructure;

/// <summary>
/// Represents the executor for application requests.
/// </summary>
public interface IMuscatRequestor
{
    /// <summary>
    /// Executes a command.
    /// </summary>
    /// <typeparam name="TResult">The type of command result.</typeparam>
    /// <param name="command">The command to execute.</param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> to observe while waiting for the task to complete.
    /// </param>
    /// <returns>
    /// The <see cref="Task"/> that represents the asynchronous operation,
    /// containing the command result.
    /// </returns>
    Task<TResult> ExecuteCommand<TResult>(ICommand<TResult> command, CancellationToken cancellationToken);
}
