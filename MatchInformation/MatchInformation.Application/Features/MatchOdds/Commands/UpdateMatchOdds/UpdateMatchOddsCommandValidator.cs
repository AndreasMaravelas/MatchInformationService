using FluentValidation;
using MatchInformation.Application.Features.Match.Commands.UpdateMatchOdds;

namespace MatchInformation.Application.Features.MatchOdds.Commands.UpdateMatchOdds
{
    public class UpdateMatchOddsCommandValidator : AbstractValidator<UpdateMatchOddsCommand>
    {
        public UpdateMatchOddsCommandValidator()
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
