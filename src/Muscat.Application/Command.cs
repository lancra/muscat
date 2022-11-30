namespace Muscat.Application;

public abstract class Command<TResult> : ICommand<TResult>
{
    public Guid Id { get; } = Guid.NewGuid();
}
