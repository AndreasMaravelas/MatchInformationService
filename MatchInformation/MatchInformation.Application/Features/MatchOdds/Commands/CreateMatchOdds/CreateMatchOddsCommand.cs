using MatchInformation.Application.Features.MatchOdds.Commands.CreateMatchOdds;
using MediatR;
using System;

namespace MatchInformation.Application.Features.Match.Commands.CreateMatchOdds
{
    public class CreateMatchOddsCommand : IRequest<CreateMatchOddsResponse>
    {
        public Guid MatchId { get; set; }
        public string Specifier { get; set; }
        public string Odd { get; set; }
    }
}
