using Muscat.Core.Domains;

namespace Muscat.Application.Domains.CreateDomain;

internal class CreateDomainCommandHandler : ICommandHandler<CreateDomainCommand, Guid>
{
    private readonly IDomainRepository _domainRepository;

    public CreateDomainCommandHandler(IDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public Task<Guid> Handle(CreateDomainCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var domain = Domain.CreateNew(request.Uri, request.Name);

        _domainRepository.Add(domain);

        return Task.FromResult(domain.Id.Value);
    }
}
