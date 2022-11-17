using System.CommandLine.Hosting;
using System.CommandLine.Invocation;
using System.CommandLine.IO;
using Microsoft.Extensions.Hosting;

namespace Muscat.Shared.Errors;

public static class ErrorHandler
{
    public static void HandleException(Exception exception, InvocationContext context)
    {
        ArgumentNullException.ThrowIfNull(exception);
        ArgumentNullException.ThrowIfNull(context);

        if (exception is HostAbortedException)
        {
            return;
        }

        context.Console.Error.WriteLine("An unhandled exception has occurred: ");
        context.Console.Error.WriteLine(exception.ToString());
    }
}
