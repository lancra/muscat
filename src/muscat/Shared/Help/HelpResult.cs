using System.CommandLine.Help;
using System.CommandLine.Invocation;
using System.CommandLine.IO;

namespace Muscat.Shared.Help;

internal class HelpResult : IInvocationResult
{
    public void Apply(InvocationContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var output = context.Console.Out.CreateTextWriter();
        var helpContext = new HelpContext(
            context.HelpBuilder,
            context.ParseResult.CommandResult.Command,
            output,
            context.ParseResult);

        context.HelpBuilder.Write(helpContext);
    }
}
