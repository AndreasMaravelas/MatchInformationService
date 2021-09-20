using MatchInformation.Application.Models;
using MediatR;
using System;

namespace MatchInformation.Application.Features.Match.Queries.GetMatchWithOdds
{
    public class GetMatchWithOddsQuery : IRequest<MatchDto>
    {
        public Guid Id { get; set; }
        public bool? WithOdds { get; set; }
    }
}
