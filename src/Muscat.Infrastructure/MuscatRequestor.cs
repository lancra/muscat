using Autofac;
using MediatR;
using Muscat.Application;

namespace Muscat.Infrastructure;

public class MuscatRequestor : IMuscatRequestor
{
    private readonly ILifetimeScope _lifetimeScope;

    public MuscatRequestor(ILifetimeScope lifetimeScope)
    {
        _lifetimeScope = lifetimeScope;
    }

    public async Task<TResult> ExecuteCommand<TResult>(ICommand<TResult> command, CancellationToken cancellationToken)
    {
        using var scope = _lifetimeScope.BeginLifetimeScope();
        var mediator = scope.Resolve<IMediator>();

        return await mediator.Send(command, cancellationToken)
            .ConfigureAwait(false);
    }
}
