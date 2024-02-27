using CookieApi.Dto;
using FluentValidation;

namespace CookieApi.Validators;

public class AddRamDtoValidator : AbstractValidator<AddRamDto>
{
    public AddRamDtoValidator()
    {
        RuleFor(x => x.Timings)
            .Matches(@"^\d+-\d+-\d+-\d+$")
            .WithMessage("wrong timings format");
    }
}