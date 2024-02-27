using CQRS.Features.SetProfileId;
using FluentValidation;

namespace CQRS.Validators;

public class SetProfileCommandValidator : AbstractValidator<SetProfileCommand>
{
    public SetProfileCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("UserId must be more than zero");
    }
}