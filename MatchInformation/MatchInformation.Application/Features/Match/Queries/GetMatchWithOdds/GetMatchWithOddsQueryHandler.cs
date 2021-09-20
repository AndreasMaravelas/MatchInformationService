using AutoMapper;
using MatchInformation.Application.Contracts.Persistence;
using MatchInformation.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Application.Features.Match.Queries.GetMatchWithOdds
{
    public class GetMatchWithOddsQueryHandler : IRequestHandler<GetMatchWithOddsQuery, MatchDto>
    {
        private readonly IMapper _mapper;
        private readonly IMatchRepository _matchRepository;

        public GetMatchWithOddsQueryHandler(IMapper mapper, IMatchRepository matchRepository)
        {
            _mapper = mapper;
            _matchRepository = matchRepository;
        }

        public async Task<MatchDto> Handle(GetMatchWithOddsQuery request, CancellationToken token = default)
        {
            var match = await _matchRepository.GetWithOddsAsync(request.Id, request.WithOdds, token);
            return _mapper.Map<MatchDto>(match);
        }
    }
}
