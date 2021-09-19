using MatchInformation.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace MatchInformation.Application.Features.Match.Queries.GetMatchOddsList
{
    public class GetMatchOddsListQuery : IRequest<IEnumerable<MatchOddsDto>>
    {
    }
}
