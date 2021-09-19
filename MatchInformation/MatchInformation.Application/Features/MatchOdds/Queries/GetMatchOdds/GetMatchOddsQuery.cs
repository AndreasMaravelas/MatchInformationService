using MatchInformation.Application.Models;
using MediatR;
using System;

namespace MatchInformation.Application.Features.Match.Queries.GetMatchOdds
{
    public class GetMatchOddsQuery : IRequest<MatchOddsDto>
    {
        public Guid Id { get; set; }
    }
}
