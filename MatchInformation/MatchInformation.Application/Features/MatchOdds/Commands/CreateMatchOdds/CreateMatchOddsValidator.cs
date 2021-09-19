using FluentValidation;
using MatchInformation.Application.Features.Match.Commands.CreateMatchOdds;

namespace MatchInformation.Application.Features.MatchOdds.Commands.CreateMatchOdds
{
    public class CreateMatchOddsValidator : AbstractValidator<CreateMatchOddsCommand>
    {
        public CreateMatchOddsValidator()
        {
            RuleFor(p => p.Odd)
                 .NotNull()
                 .WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Specifier)
                 .NotNull()
                 .WithMessage("{PropertyName} is required.");
        }
    }
}
