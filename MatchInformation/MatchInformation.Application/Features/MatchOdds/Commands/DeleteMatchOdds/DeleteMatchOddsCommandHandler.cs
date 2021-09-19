using AutoMapper;
using MatchInformation.Application.Contracts.Persistence;
using MatchInformation.Application.Exceptions;
using MatchInformation.Application.Features.Match.Commands.DeleteMatchOdds;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Application.Features.MatchOdds.Commands.DeleteMatchOdds
{
    public class DeleteMatchOddsCommandHandler : IRequestHandler<DeleteMatchOddsCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMatchOddsRepository _matchOddsRepository;

        public DeleteMatchOddsCommandHandler(IMapper mapper, IMatchOddsRepository matchOddsRepository)
        {
            _mapper = mapper;
            _matchOddsRepository = matchOddsRepository;
        }

        public async Task<Unit> Handle(DeleteMatchOddsCommand request, CancellationToken cancellationToken)
        {
            var matchOdds = await _matchOddsRepository.GetByIdAsync(request.Id);

            if (matchOdds == null)
            {
                throw new NotFoundException(nameof(Match), request.Id);
            }

            await _matchOddsRepository.DeleteAsync(matchOdds);

            return Unit.Value;
        }
    }
}
