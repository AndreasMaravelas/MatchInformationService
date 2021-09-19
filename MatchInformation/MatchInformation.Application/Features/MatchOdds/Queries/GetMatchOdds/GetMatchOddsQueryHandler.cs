using AutoMapper;
using MatchInformation.Application.Contracts.Persistence;
using MatchInformation.Application.Features.Match.Queries.GetMatchOdds;
using MatchInformation.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Application.Features.MatchOdds.Queries.GetMatchOdds
{
    public class GetMatchOddsQueryHandler : IRequestHandler<GetMatchOddsQuery, MatchOddsDto>
    {
        private readonly IMapper _mapper;
        private readonly IMatchOddsRepository _matchOddsRepository;

        public GetMatchOddsQueryHandler(IMapper mapper, IMatchOddsRepository matchOddsRepository)
        {
            _mapper = mapper;
            _matchOddsRepository = matchOddsRepository;
        }

        public async Task<MatchOddsDto> Handle(GetMatchOddsQuery request, CancellationToken token = default)
        {
            var match = await _matchOddsRepository.GetByIdAsync(request.Id, token);
            return _mapper.Map<MatchOddsDto>(match);
        }
    }
}
