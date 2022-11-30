using Muscat.Application;

namespace Muscat.Infrastructure.Configuration.Processing;

public class UnitOfWorkCommandHandlerDecorator<TCommand, TResult> : ICommandHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    private readonly ICommandHandler<TCommand, TResult> _commandHandler;
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkCommandHandlerDecorator(ICommandHandler<TCommand, TResult> commandHandler, IUnitOfWork unitOfWork)
    {
        _commandHandler = commandHandler;
        _unitOfWork = unitOfWork;
    }

    public async Task<TResult> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var result = await _commandHandler.Handle(request, cancellationToken)
            .ConfigureAwait(false);

        await _unitOfWork.Commit(cancellationToken)
            .ConfigureAwait(false);

        return result;
    }
}
