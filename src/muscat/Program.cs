using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Muscat;
using Muscat.Core;
using Muscat.Infrastructure;
using Muscat.Shared.Errors;

await new CommandLineBuilder(new MuscatCommand())
    .UseVersionOption()
    .UseHelp()
    .UseEnvironmentVariableDirective()
    .UseParseDirective()
    .UseSuggestDirective()
    .RegisterWithDotnetSuggest()
    .UseTypoCorrections()
    .UseParseErrorReporting()
    .UseExceptionHandler(ErrorHandler.HandleException)
    .CancelOnProcessTermination()
    .UseHost(host => host
        .ConfigureHostConfiguration(config => config.AddEnvironmentVariables("MUSCAT_"))
        .ConfigureServices((hostingContext, services) => services
            .AddMuscat()
            .AddMuscatCore()
            .AddMuscatInfrastructure(DatabaseLocationProvider.ResolvePath(hostingContext.HostingEnvironment))))
    .Build()
    .InvokeAsync(args)
    .ConfigureAwait(false);
