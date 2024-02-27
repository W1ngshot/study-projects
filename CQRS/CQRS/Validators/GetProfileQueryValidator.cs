using CQRS.Features.Profile;
using FluentValidation;

namespace CQRS.Validators;

public class GetProfileQueryValidator : AbstractValidator<GetProfileQuery>
{
    public GetProfileQueryValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("UserId must be more than zero");
    }
}