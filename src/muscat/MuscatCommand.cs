using System.CommandLine;
using Muscat.Shared.Help;

namespace Muscat;

public class MuscatCommand : RootCommand
{
    public MuscatCommand()
        : base("Music Cataloger")
    {
        Handler = HelpCommandHandler.Create();
    }
}
