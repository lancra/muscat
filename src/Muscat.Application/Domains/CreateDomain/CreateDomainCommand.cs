namespace Muscat.Application.Domains.CreateDomain;

public class CreateDomainCommand : Command<Guid>
{
    public CreateDomainCommand(Uri uri, string name)
    {
        Uri = uri;
        Name = name;
    }

    public Uri Uri { get; }

    public string Name { get; }
}
