using AutoMapper;
using MatchInformation.Application.Contracts.Persistence;
using MatchInformation.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Application.Features.Match.Queries.GetMatch
{
    public class GetMatchQueryHandler : IRequestHandler<GetMatchQuery, MatchDto>
    {
        private readonly IMapper _mapper;
        private readonly IMatchRepository _matchRepository;

        public GetMatchQueryHandler(IMapper mapper, IMatchRepository matchRepository)
        {
            _mapper = mapper;
            _matchRepository = matchRepository;
        }

        public async Task<MatchDto> Handle(GetMatchQuery request, CancellationToken token = default)
        {
            var match = await _matchRepository.GetByIdAsync(request.Id, token);
            return _mapper.Map<MatchDto>(match);
        }
    }
}
