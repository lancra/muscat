using Muscat.Core.Links;

namespace Muscat.Application.Links.CreateLink;

internal class CreateLinkCommandHandler : ICommandHandler<CreateLinkCommand, Guid>
{
    private readonly ILinkRepository _linkRepository;

    public CreateLinkCommandHandler(ILinkRepository linkRepository)
    {
        _linkRepository = linkRepository;
    }

    public Task<Guid> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var link = Link.CreateNew(request.Domain, request.Name);

        _linkRepository.Add(link);

        return Task.FromResult(link.Id.Value);
    }
}
