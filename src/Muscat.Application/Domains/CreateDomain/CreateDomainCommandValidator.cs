using FluentValidation;

namespace Muscat.Application.Domains.CreateDomain;

internal class CreateDomainCommandValidator : AbstractValidator<CreateDomainCommand>
{
    public CreateDomainCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Domain name cannot be empty");
    }
}
