namespace Muscat.Application.Links.CreateLink;

public class CreateLinkCommand : Command<Guid>
{
    public CreateLinkCommand(Uri domain, string name)
    {
        Domain = domain;
        Name = name;
    }

    public Uri Domain { get; }

    public string Name { get; }
}
