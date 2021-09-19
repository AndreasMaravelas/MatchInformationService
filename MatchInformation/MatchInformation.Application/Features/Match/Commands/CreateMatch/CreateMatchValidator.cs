using FluentValidation;

namespace MatchInformation.Application.Features.Match.Commands.CreateMatch
{
    public class CreateMatchValidator : AbstractValidator<CreateMatchCommand>
    {
        public CreateMatchValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");

            RuleFor(p => p.MatchDateTime)
                 .NotNull()
                 .WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Sport)
                 .NotNull()
                 .WithMessage("{PropertyName} is required.");

            RuleFor(p => p.TeamA)
                 .NotNull()
                 .WithMessage("{PropertyName} is required.")
                 .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");

            RuleFor(p => p.TeamB)
                 .NotNull()
                 .WithMessage("{PropertyName} is required.")
                 .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");
        }
    }
}
