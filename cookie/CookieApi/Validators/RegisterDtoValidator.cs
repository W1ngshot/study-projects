using CookieApi.Dto;
using FluentValidation;

namespace CookieApi.Validators;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Nickname)
            .NotEmpty()
            .WithMessage("nickname cant be empty")
            .MinimumLength(3)
            .WithMessage("too short nickname")
            .MaximumLength(40)
            .WithMessage("too long nickname");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("password cant be empty")
            .MinimumLength(6)
            .WithMessage("too short password");
    }
}