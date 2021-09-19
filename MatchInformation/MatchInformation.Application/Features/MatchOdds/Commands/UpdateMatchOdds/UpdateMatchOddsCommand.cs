using MediatR;
using System;

namespace MatchInformation.Application.Features.Match.Commands.UpdateMatchOdds
{
    public class UpdateMatchOddsCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Specifier { get; set; }
        public string Odd { get; set; }
    }
}
