using MatchInformation.Application.Models;
using MediatR;
using System;

namespace MatchInformation.Application.Features.Match.Queries.GetMatch
{
    public class GetMatchQuery : IRequest<MatchDto>
    {
        public Guid Id { get; set; }
    }
}
