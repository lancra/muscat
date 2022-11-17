using System.CommandLine.Invocation;
using System.CommandLine.NamingConventionBinder;

namespace Muscat.Shared.Help;

internal class HelpCommandHandler : ICommandHandler
{
    public static ICommandHandler Create()
        => CommandHandler.Create<InvocationContext>(context => new HelpCommandHandler().InvokeAsync(context));

    public int Invoke(InvocationContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        context.InvocationResult = new HelpResult();

        return ExitCodes.Success;
    }

    public Task<int> InvokeAsync(InvocationContext context)
        => Task.FromResult(Invoke(context));
}
