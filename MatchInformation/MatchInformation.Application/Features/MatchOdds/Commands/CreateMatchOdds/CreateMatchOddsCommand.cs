using MatchInformation.Application.Features.MatchOdds.Commands.CreateMatchOdds;
using MatchInformation.Application.Models;
using MediatR;
using System;

namespace MatchInformation.Application.Features.Match.Commands.CreateMatchOdds
{
    public class CreateMatchOddsCommand : IRequest<CreateMatchOddsResponse>
    {
        public Guid MatchId { get; set; }
        public Specifier Specifier { get; set; }
        public double Odd { get; set; }
    }
}
