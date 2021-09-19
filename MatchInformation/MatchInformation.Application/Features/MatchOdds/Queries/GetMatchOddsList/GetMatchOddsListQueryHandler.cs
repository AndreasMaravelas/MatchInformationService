using AutoMapper;
using MatchInformation.Application.Contracts.Persistence;
using MatchInformation.Application.Features.Match.Queries.GetMatchOddsList;
using MatchInformation.Application.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Application.Features.MatchOdds.Queries.GetMatchOddsList
{
    public class GetMatchOddsListQueryHandler : IRequestHandler<GetMatchOddsListQuery, IEnumerable<MatchOddsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMatchOddsRepository _matchOddsRepository;

        public GetMatchOddsListQueryHandler(IMapper mapper, IMatchOddsRepository matchOddsRepository)
        {
            _mapper = mapper;
            _matchOddsRepository = matchOddsRepository;
        }

        public async Task<IEnumerable<MatchOddsDto>> Handle(GetMatchOddsListQuery request, CancellationToken token = default)
        {
            var matchList = (await _matchOddsRepository.ListAllAsync(token)).OrderBy(x => x.MatchId);
            return _mapper.Map<IEnumerable<MatchOddsDto>>(matchList);
        }
    }
}
