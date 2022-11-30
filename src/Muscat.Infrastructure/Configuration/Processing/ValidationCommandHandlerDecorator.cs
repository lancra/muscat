using FluentValidation;
using Muscat.Application;

namespace Muscat.Infrastructure.Configuration.Processing;

public class ValidationCommandHandlerDecorator<TCommand, TResult> : ICommandHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    private readonly ICommandHandler<TCommand, TResult> _commandHandler;
    private readonly IList<IValidator<TCommand>> _validators;

    public ValidationCommandHandlerDecorator(ICommandHandler<TCommand, TResult> commandHandler, IList<IValidator<TCommand>> validators)
    {
        _commandHandler = commandHandler;
        _validators = validators;
    }

    public async Task<TResult> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var validationFailures = _validators.Select(validator => validator.Validate(request))
            .SelectMany(validationResult => validationResult.Errors)
            .Where(validationFailure => validationFailure is not null)
            .ToArray();
        if (validationFailures.Any())
        {
            throw new InvalidCommandException(validationFailures.Select(validationFailure => validationFailure.ErrorMessage)
                .ToArray());
        }

        return await _commandHandler.Handle(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
