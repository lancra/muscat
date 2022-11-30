using MediatR;

namespace Muscat.Application;

/// <summary>
/// Represents a command to modify the application.
/// </summary>
/// <typeparam name="TResult">The type of result returned from the command.</typeparam>
public interface ICommand<TResult> : IRequest<TResult>
{
    /// <summary>
    /// Gets the unique identifier.
    /// </summary>
    Guid Id { get; }
}
