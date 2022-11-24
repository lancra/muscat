using MediatR;

namespace Muscat.Core.SharedKernel;

/// <summary>
/// Represents an event which occurred in the domain.
/// </summary>
public interface IDomainEvent : INotification
{
    /// <summary>
    /// Gets the unique event identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets the date the event occurred.
    /// </summary>
    public DateTime DateOccurred { get; }
}
