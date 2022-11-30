using FluentValidation;

namespace Muscat.Application.Links.CreateLink;

internal class CreateLinkCommandValidator : AbstractValidator<CreateLinkCommand>
{
    public CreateLinkCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Link name cannot be empty");
    }
}
