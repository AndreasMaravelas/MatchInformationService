using MatchInformation.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace MatchInformation.Application.Features.Match.Queries.GetMatchList
{
    public class GetMatchListQuery : IRequest<IEnumerable<MatchDto>>
    {
        //public DateTime From { get; set; }
        //public DateTime To { get; set; }
        //public int Page { get; set; }
        //public int Size { get; set; }
    }
}
