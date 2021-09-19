using AutoMapper;
using MatchInformation.Application.Contracts.Persistence;
using MatchInformation.Application.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Application.Features.Match.Queries.GetMatchList
{
    public class GetMatchListQueryHandler : IRequestHandler<GetMatchListQuery, IEnumerable<MatchDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMatchRepository _matchRepository;

        public GetMatchListQueryHandler(IMapper mapper, IMatchRepository matchRepository)
        {
            _mapper = mapper;
            _matchRepository = matchRepository;
        }

        public async Task<IEnumerable<MatchDto>> Handle(GetMatchListQuery request, CancellationToken token = default)
        {
            var matchList = await _matchRepository.GetPagedMatchesForPeriod(request.From, request.To, request.Page, request.Size, token);
            return _mapper.Map<IEnumerable<MatchDto>>(matchList);
        }
    }
}
